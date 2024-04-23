using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JetHealth.Models
{
    public class TProcedure
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
                if (value < 0)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _id = value;
            }
        }
        public string Name { get; set; }
        [DisplayName("Процедура")]
        public string PDescription { get; set; }
        [ForeignKey("Treatment")]
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
		[ValidateNever]
		public Treatment Treatment { get; set; }
        [NotMapped, ValidateNever]
        public IEnumerable<SelectListItem> Treatments { get; set; }
    }
}
