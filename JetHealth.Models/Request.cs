using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetHealth.Models.Abstract;
namespace JetHealth.Models
{
    public class Request:Message
    {
        [NotMapped]
        private string _name;
        [NotMapped]
        private string _phoneNumber;
        [MinLength(1),MaxLength(30),DisplayName("Ваше ім'я")]
        public override string Name 
        { 
            get { return _name; } 
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _name = value;
            }
        }
        [StringLength(13), DisplayName("Номер телефону у форматі +380..")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length !=13)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _phoneNumber = value;
            }
        }
    }
}
