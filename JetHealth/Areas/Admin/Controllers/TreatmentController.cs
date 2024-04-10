using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JetHealth.Utility;

namespace JetHealth.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles =$"{SD.ROLEAdmin},{SD.ROLEDoctor}")]
	public class TreatmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Upsert(int? Id)
		{
			return View();
		}
		public IActionResult Delete(int Id)
		{
			return View();
		}
	}
}
