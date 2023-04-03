namespace WebApp.ViewModels
{
    public class RowCollectionViewModel
    {
        public string Title { get; set; } = "";
        public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;
        public bool LoadMore { get; set; } = false;

    }
}
