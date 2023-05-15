namespace WebApp.Models.Dto
{
    public class Product
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!; //Eller ProductName som det var tidigare?
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? ImageUrl { get; set; }


        public ProductCategory ProductCategory { get; set; } = null!;
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}
