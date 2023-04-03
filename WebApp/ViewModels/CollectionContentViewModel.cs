namespace WebApp.ViewModels
{
    public class CollectionContentViewModel
    {
        public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;

        public IEnumerable<CollectionContentItemViewModel> Item { get; set; } = null!;
    }
}
