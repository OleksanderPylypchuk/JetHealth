using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetHealth.Models.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;

namespace JetHealth.Models
{
    public class Request:Message
    {
        [NotMapped]
        private string _name;
        [NotMapped]
        private string _phoneNumber;
        [MinLength(1),MaxLength(20)]
        public string Name 
        { 
            get { return _name; } 
            set
            {
                if (value.IsNullOrEmpty() || value.Length > 20)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _name = value;
            }
        }
        [StringLength(10)]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value.IsNullOrEmpty() || value.Length !=10)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _phoneNumber = value;
            }
        }
    }
}
