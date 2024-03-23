using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetHealth.Models.Abstract;
using Microsoft.IdentityModel.Tokens;

namespace JetHealth.Models
{
    public class Review:Message
    {
        [NotMapped]
        private string _name;
        [NotMapped]
        private byte _rating;
        [MinLength(1), MaxLength(20)]
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
        [Range(1, 5)]
        public byte Rating
        {
            get { return _rating; }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _rating = value;
            }
        }
    }
}
