using WebApi.Models.Entities;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Schemas
{
    public class ProductSchema : IProduct
    {
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCategoryId { get; set; }

        public List<string> Tags { get; set; } = new List<string>();
        
        public static implicit operator ProductEntity(ProductSchema schema)
        {
            if (schema != null)
            {
  
                return new ProductEntity
                {
                    ArticleNumber = schema.ArticleNumber,
                    ProductName = schema.ProductName,
                    ProductDescription = schema.ProductDescription,
                    ProductPrice = schema.ProductPrice,
                    ProductCategoryId = schema.ProductCategoryId,
                };
            }

            return null!;
        }
    }
}
