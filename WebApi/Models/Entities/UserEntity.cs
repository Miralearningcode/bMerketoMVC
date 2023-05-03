using Microsoft.AspNetCore.Identity;

namespace WebApi.Models.Entities
{
    public class UserEntity : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
    }
}
