using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class AuthenticationService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AddressService _addressService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<bool> RegisterUserAsync(UserRegisterViewModel viewModel)
        {
            AppUser appUser = viewModel;
            var roleName = "user";

            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);


                var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                }
            }

            return false;
        }


        public async Task<bool> LoginAsync(UserLoginViewModel viewModel)
        {
            var AppUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
            if (AppUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(AppUser, viewModel.Password, viewModel.RememberMe, false);
                return result.Succeeded;
            }

            return false;
        }

        private async Task<UserRolesViewModel> GenerateUserRolesViewModel(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return new UserRolesViewModel
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                Roles = roles.ToList()
            };
        }

        public async Task<List<UserRolesViewModel>> GetAllUsersWithRolesAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModels = new List<UserRolesViewModel>();
            foreach (var user in users)
            {
                var userRolesViewModel = await GenerateUserRolesViewModel(user);
                userRolesViewModels.Add(userRolesViewModel);
            }
            return userRolesViewModels;
        }
    }
}
