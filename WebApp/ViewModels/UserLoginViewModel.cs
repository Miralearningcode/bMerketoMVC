using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class UserLoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
