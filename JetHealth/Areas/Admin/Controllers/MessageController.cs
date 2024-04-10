using JetHealth.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.ROLEAdmin}")]
    public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult DeleteReview(int Id)
		{
			return View();
		}
		public IActionResult DeleteRequest(int Id)
		{
			return View();
		}
	}
}
