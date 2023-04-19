using System.ComponentModel.DataAnnotations;
using WebApp.Models.Identity;

namespace WebApp.ViewModels
{
    public class UserRegistrationViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Phone Number (optional)")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Company (optional)")]
        public string? Company{ get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You must confirm your password.")]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "Street name is required.")]
        public string StreetName { get; set; } = null!;

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Postal code is required.")]
        public string PostalCode { get; set; } = null!;

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = null!;



        public static implicit operator CustomIdentityUser(UserRegistrationViewModel viewModel)
        {
            return new CustomIdentityUser
            {
                UserName = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber
            };
        }
    }
}
