using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var roles = _roleManager.Roles.ToList();

            var userRoles = new List<UserRolesViewModel>();
            foreach (var user in users)
            {
                var roleNames = await _userManager.GetRolesAsync(user);
                var roleIds = new List<string>();
                foreach (var roleName in roleNames)
                {
                    var role = roles.FirstOrDefault(r => r.Name == roleName);
                    if (role != null)
                    {
                        roleIds.Add(role.Id);
                    }
                }

                var userRole = new UserRolesViewModel
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email!,
                    Roles = roleIds
                };

                userRoles.Add(userRole);
            }

            return View((userRoles, _userManager));
        }
    }
}
