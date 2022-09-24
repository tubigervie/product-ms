using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models
{
    public class Product
    {
        [Key] //annotation that specifies that this is the primary key
        public int ProductId { get; set; }

        [Required] //ensures a non-nullable field in DB
        public string Name { get; set; }

        [Range(1, 1000)] //in USD
        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; } //TODO : move this category into another table

        public string ImageUrl { get; set; }

    }
}
