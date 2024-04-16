﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JetHealth.Models.ViewModels
{
	public class UserVM
	{
		public ApplicationUser User { get; set; }
		public List<SelectListItem> Roles { get; set; }
	}
}
