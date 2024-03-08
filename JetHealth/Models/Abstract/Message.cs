using System.ComponentModel.DataAnnotations;

namespace JetHealth.Models.Abstract
{
    public abstract class Message
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
