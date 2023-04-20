using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class AuthenticationService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly AddressService _addressService;

        public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService)
        {
            _userManager = userManager;
            _addressService = addressService;
        }

        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<bool> RegisterUserAsync(UserRegisterViewModel viewModel)
        {
            AppUser appUser = viewModel;

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);
            if (result.Succeeded)
            {
                var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
                if (addressEntity != null) 
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                }
            }

            return false;
        }
    }
}
