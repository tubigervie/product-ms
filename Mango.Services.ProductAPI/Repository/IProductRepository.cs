using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        //What will be all the methods needed to perform CRUD operations on Products?
        Task<IEnumerable<ProductDto>> GetProducts(); //tasks represent asynchronous operations
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
