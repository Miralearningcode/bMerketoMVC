﻿namespace WebApp.ViewModels
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public IList<string> Roles { get; set; } = null!;
    }
}
