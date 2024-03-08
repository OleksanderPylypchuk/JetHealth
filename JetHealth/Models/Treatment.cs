namespace JetHealth.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string TreatmentName { get; set; }
        public List<TImage> TreatmentImages { get; set;}
        public int TreatmentDescriptionId { get; set; }
        public TDescription TreatmentDescription { get; set; }
        public List<TProcedure> TreatmentProcedures { get; set; }
    }
}
