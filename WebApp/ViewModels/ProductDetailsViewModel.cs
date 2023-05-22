namespace WebApp.ViewModels
{
    public class ProductDetailsViewModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? ImageUrl { get; set; }



        public GridCollectionViewModel All { get; set; } = null!;
    }
}
