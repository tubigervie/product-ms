using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
                return Ok(_response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<String>() { ex.ToString() };
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<object> GetById(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                if (productDto == null) return NotFound();
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<String>() { ex.ToString() };
                return NotFound();
            }
            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<String>() { ex.ToString() };
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = productDto.ProductId }, _response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<object> Put([FromBody] ProductDto productDto) //basically same as POST but the actual logic that makes Put/post different lies within the repository
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<String>() { ex.ToString() };
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = productDto.ProductId }, _response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<object> DeleteById(int id)
        {
            try
            {
                bool isSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<String>() { ex.ToString() };
                return BadRequest();
            }
            return Ok(_response);
        }

    }
}
