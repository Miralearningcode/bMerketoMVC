using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public class MessageEntity
    {
        [Key]
        public int Id { get; set; }
        public string MessageText { get; set; } = null!;
    }
}
