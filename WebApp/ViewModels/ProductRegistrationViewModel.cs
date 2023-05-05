using WebApp.Models.Entities;

namespace WebApp.ViewModels
{
    public class ProductRegistrationViewModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;




        public static implicit operator ProductEntity(ProductRegistrationViewModel viewModel)
        {
            return new ProductEntity
            {
                ArticleNumber = viewModel.ArticleNumber,
                ProductName = viewModel.Name
            };
        }
    }
}