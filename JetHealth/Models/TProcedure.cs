namespace JetHealth.Models
{
    public class TProcedure
    {
        public int Id { get; set; }
        public string PDescription { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
