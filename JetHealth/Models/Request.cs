using JetHealth.Models.Abstract;

namespace JetHealth.Models
{
    public class Request:Message
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
