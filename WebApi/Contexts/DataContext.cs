using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<ProductTagEntity> ProductTags { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    }
}
