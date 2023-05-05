using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositiories
{
    public class TagRepository : Repo<TagEntity>
    {
        public TagRepository(IdentityContext context) : base(context)
        {
        }
    }
}
