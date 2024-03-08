using Microsoft.AspNetCore.Identity;

namespace JetHealth.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
