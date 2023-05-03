using WebApi.Contexts;

namespace WebApi.Helpers.Repositories
{
    public class ProductTagRepo : Repo<ProductTagEntity>
    {
        public ProductTagRepo(DataContext context) : base(context)
        {
        }
    }
}
