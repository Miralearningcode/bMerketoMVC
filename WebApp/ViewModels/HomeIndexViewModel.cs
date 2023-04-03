namespace WebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";
        public GridCollectionViewModel BestCollection { get; set; } = null!;
        public RowCollectionViewModel TopSellingCollection { get; set; } = null!;
        public CollectionContentViewModel UpToSaleCollection { get; set; } = null!;
        public CollectionContentViewModel UpToSaleCard { get; set; } = null!;
    }
}
