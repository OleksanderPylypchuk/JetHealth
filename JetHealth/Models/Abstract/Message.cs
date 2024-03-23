using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JetHealth.Models.Abstract
{
    public abstract class Message
    {
        [NotMapped]
        private int _id;
        [Key]
        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _id = value;
            }
        }
        public string? Content { get; set; }
    }
}
