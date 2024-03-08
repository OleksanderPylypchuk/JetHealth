namespace JetHealth.Models
{
    public class TImage
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
