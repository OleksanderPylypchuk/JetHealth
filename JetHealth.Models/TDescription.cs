using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        [DisplayName("Опис напряму")]
        public string Description { get; set; }
        [ForeignKey("Treatment")]
        public int TreatmentId
        {
            get { return _treatmentid; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _treatmentid = value;
            }
        }
    }
}
