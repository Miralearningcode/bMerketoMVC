using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> AspNetAddresses { get; set; }
        public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<ProductTagEntity> ProductTags { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roleId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
            


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                    Id = roleId,
                    Name = "System Administrator",
                    NormalizedName = "SYSTEM ADMINISTRATOR"
                }
            );

            var passwordHasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = userId,
                FirstName = " ",
                LastName = " ",
                UserName = "administrator@domain.com",
                Email = "administrator@domain.com",
                PasswordHash = passwordHasher.HashPassword(null!, "Bytmig123!")
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId,
            });
        }
        */
    }
}
 