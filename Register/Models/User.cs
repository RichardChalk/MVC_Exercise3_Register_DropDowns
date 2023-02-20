using Microsoft.AspNetCore.Mvc.Rendering;

namespace Register.ViewModels
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CountryLabel { get; set; } = null!;
        public string UserTypeLabel { get; set; } = null!;
        public bool SendMeUpdates { get; set; } = false;

    }
}
