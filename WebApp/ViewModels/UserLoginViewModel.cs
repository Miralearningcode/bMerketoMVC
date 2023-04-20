using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class UserLoginViewModel
    {

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must enter a e-mail address")]
        public string Email { get; set; } = null!;


        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password")]
        public string Password { get; set; } = null!;


        [Display(Name = "Keep me signed in")]
        public bool RememberMe { get; set; } = false!;
    }
}
