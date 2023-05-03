using WebApi.Contexts;

namespace WebApi.Helpers.Repositories
{
    public class TagRepo : Repo<TagEntity>
    {
        public TagRepo(DataContext context) : base(context)
        {
        }
    }
}
