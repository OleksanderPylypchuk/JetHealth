using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JetHealth.Models.ViewModels
{
	public class TreatmentVM
	{
		public Treatment Treatment { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> Users { get; set; }
	}
}
