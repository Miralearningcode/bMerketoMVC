using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public class ContactFormEntity
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Company { get; set; } 
        public bool SaveInfo { get; set; }
        public int MessageId { get; set; }
    }
}
