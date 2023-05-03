using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Schemas
{
    public class ProductSchema : IProduct
    {
        [Required]
        public string ArticleNumber { get; set; } = null!;

        [Required]
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public IFormFile? Image { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }
        public int ProductCategoryId { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
        
        public static implicit operator ProductEntity(ProductSchema schema)
        {
            var entity = new ProductEntity
            {
                ArticleNumber = schema.ArticleNumber,
                ProductName = schema.ProductName,
                ProductDescription = schema.ProductDescription,
                ProductPrice = schema.ProductPrice,
                ProductCategoryId = schema.ProductCategoryId,
            };

            if (schema.Image != null )
            {
                entity.ImageUrl = $"{entity.ArticleNumber}_{schema.Image.FileName}";
            }

            return entity;
        }
    }
}
