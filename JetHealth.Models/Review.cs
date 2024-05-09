using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetHealth.Models.Abstract;

namespace JetHealth.Models
{
    public class Review:Message
    {
        [NotMapped]
        private string _name;
        [NotMapped]
        private byte _rating;
        [MinLength(1), MaxLength(30), DisplayName("Коментар")]
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
