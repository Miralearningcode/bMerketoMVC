using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositiories
{
    public class UserAddressRepository : Repository<UserAddressEntity>
    {
        public UserAddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
