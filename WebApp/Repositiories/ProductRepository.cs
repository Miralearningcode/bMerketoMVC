using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositiories
{
    public class ProductRepository : Repo<ProductEntity>
    {
        public ProductRepository(IdentityContext context) : base(context)
        {
        }
    }
}
