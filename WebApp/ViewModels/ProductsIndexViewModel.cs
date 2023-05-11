using WebApp.Models.Dto;

namespace WebApp.ViewModels
{
    public class ProductsIndexViewModel
    {
        public string Title { get; set; } = "Products";
        public GridCollectionViewModel All { get; set; } = null!;
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
