using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace JetHealth.Models
{
    public class ApplicationUser:IdentityUser
    {
        [NotMapped]
        private string _firstName;
        [NotMapped]
        private string _lastName;
        [MinLength(1), MaxLength(15)]
        public string FirstName { get { return _firstName; } set {
                if (value.IsNullOrEmpty() || value.Length > 15)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _firstName = value;
            } 
        }
        [MinLength(1), MaxLength(15)]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.IsNullOrEmpty() || value.Length > 15)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _lastName = value;
            }
        }
    }
}
