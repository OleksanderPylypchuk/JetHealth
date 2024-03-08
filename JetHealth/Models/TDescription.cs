namespace JetHealth.Models
{
    public class TDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
