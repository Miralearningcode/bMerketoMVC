using WebApi.Contexts;

namespace WebApi.Helpers.Repositories
{
    public class ProductCategoryRepo : Repo<ProductCategoryEntity>
    {
        public ProductCategoryRepo(DataContext context) : base(context)
        {
        }
    }
}
