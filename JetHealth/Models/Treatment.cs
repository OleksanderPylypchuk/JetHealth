﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.IdentityModel.Tokens;

namespace JetHealth.Models
{
    public class Treatment
    {
        [NotMapped]
        private int _id;
        [NotMapped]
        private string _treatmentname;
        [NotMapped]
        private int? _descriptionid;
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
        [MinLength(1), MaxLength(20)]
        public string TreatmentName
        {
            get { return _treatmentname; }
            set
            {
                if (value.IsNullOrEmpty() || value.Length > 15)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _treatmentname = value;
            }
        }
        public List<TImage> TreatmentImages { get; set;}
        [ForeignKey("TreatmentDescription")]
        public int? TreatmentDescriptionId
        {
            get { return _descriptionid; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value is not acceptable");
                }
                _descriptionid = value;
            }
        }
        public TDescription? TreatmentDescription { get; set; }
        public List<TProcedure> TreatmentProcedures { get; set; }
    }
}
