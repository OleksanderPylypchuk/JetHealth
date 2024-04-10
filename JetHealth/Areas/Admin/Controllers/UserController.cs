using JetHealth.Data.Repository.IRepository;
using JetHealth.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.ROLEAdmin}")]
    public class UserController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public UserController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<IActionResult> Index()
		{
			var users = await _unitOfWork.UserRepository.GetAllAsync();
			return View(users);
		}
		public IActionResult RoleManagement()
		{
			return View();
		}
		public IActionResult Delete(int Id)
		{
			return View();
		}
	}
}
