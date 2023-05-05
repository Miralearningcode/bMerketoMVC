using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApp.Models.Entities
{
    public class ProductEntity 
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        
        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

    }
}
