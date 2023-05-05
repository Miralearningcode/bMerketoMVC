using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositiories
{
    public class ProductTagRepository : Repo<ProductTagEntity>
    {
        public ProductTagRepository(IdentityContext context) : base(context)
        {
        }
    }
}
