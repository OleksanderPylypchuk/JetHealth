using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace JetHealth.Models.ViewModels
{
	public class HomeVM
	{
		public Request? request { get; set; }
		[ValidateNever]
		public IEnumerable<Treatment> Treatments { get; set; }
	}
}
