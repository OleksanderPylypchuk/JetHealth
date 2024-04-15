using System.ComponentModel.DataAnnotations.Schema;

namespace JetHealth.Models
{
    public class TDescription
    {
        [NotMapped]
        private int _id;
        [NotMapped]
        private int _treatmentid;
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
        public string Description { get; set; }
        public int TreatmentId
        {
            get { return _treatmentid; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _treatmentid = value;
            }
        }
        public Treatment Treatment { get; set; }
    }
}
