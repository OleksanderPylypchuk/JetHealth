using JetHealth.Models.Abstract;

namespace JetHealth.Models
{
    public class Review:Message
    {
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
