using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Dto;

namespace WebApp.Models.Entities
{
    public class ProductEntity 
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        
        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();


        public static implicit operator Product(ProductEntity entity)
        {
            return new Product
            {
                ArticleNumber = entity.ArticleNumber,
                Name = entity.Name,
                ImageUrl = entity.ImageUrl,
            };
        }

    }
}
