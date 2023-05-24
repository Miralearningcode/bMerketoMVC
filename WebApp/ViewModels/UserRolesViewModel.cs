using Microsoft.AspNetCore.Identity;

namespace WebApp.ViewModels
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public IList<string> Roles { get; set; } = null!;

        public async Task LoadUserRoles<TUser>(UserManager<TUser> userManager) where TUser : class
        {
            var user = await userManager.FindByIdAsync(UserId);
            if (user != null)
            {
                Roles = await userManager.GetRolesAsync(user);
            }
        }

    }
}
