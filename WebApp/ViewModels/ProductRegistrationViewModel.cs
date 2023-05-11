using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels
{
    public class ProductRegistrationViewModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;


        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }



        public static implicit operator ProductEntity(ProductRegistrationViewModel viewModel)
        {
            var entity = new ProductEntity
            {
                ArticleNumber = viewModel.ArticleNumber,
                Name = viewModel.Name
            };

            if (viewModel.Image != null )
                entity.ImageUrl = $"{viewModel.ArticleNumber}_{viewModel.Image?.FileName}";
            
            return entity;
        
        }
    }
}