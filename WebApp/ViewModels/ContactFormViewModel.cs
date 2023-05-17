using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.ViewModels
{
    public class ContactFormViewModel
    {
        [Display(Name = "Your Name*")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;


        [Display(Name = "Your Email*")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must enter a valid E-mail address")]
        public string Email { get; set; } = null!;


        [Display(Name = "Phone Number (optional)")]
        public string? Phone { get; set; }


        [Display(Name = "Comapny (optional)")]
        public string? Company { get; set; }


        [Display(Name = "Message*")]
        [Required(ErrorMessage = "Message is required")]
        public string MessageText { get; set; } = null!;


        [Display(Name = "Save my name, email in this browser for the next time I comment.")]
        public bool SaveInfo { get; set; } = false!;



        public static implicit operator ContactFormEntity(ContactFormViewModel viewModel)
        {
            return new ContactFormEntity
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Company = viewModel.Company,
            };
        }

        public static implicit operator MessageEntity(ContactFormViewModel viewModel)
        {
            return new MessageEntity
            {
                MessageText = viewModel.MessageText
            };
        }
    }
}
