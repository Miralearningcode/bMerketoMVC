using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;

namespace WebApp.Repositiories
{
    //CRUD - CREATE,READ,UPDATE,DELETE
    public abstract class Repo<TEntity> where TEntity : class
    {
        #region Constructors & Private Fields

        private readonly IdentityContext _context;

        protected Repo(IdentityContext context)
        {
            _context = context;
        }

        #endregion

        //Virtual = Överskrivningsbar
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var item = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                return item!;
            }
            catch { return null!; }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var items = await _context.Set<TEntity>().ToListAsync();
                return items!;
            }
            catch { return null!; }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var items = await _context.Set<TEntity>().Where(expression).ToListAsync();
                return items!;
            }
            catch { return null!; }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch { return null!; }
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
