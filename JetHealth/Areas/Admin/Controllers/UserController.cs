using JetHealth.Data.Repository.IRepository;
using JetHealth.Models;
using JetHealth.Models.ViewModels;
using JetHealth.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JetHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.ROLEAdmin}")]
    public class UserController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public UserController(IUnitOfWork unitOfWork,UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_unitOfWork = unitOfWork;
			_roleManager = roleManager;
			_userManager = userManager;
		}
		public async Task<IActionResult> Index()
		{
			var users = await _unitOfWork.UserRepository.GetAllAsync();
			return View(users);
		}
		public async Task<IActionResult> RoleManagement(string id)
		{
			UserVM userVM = new UserVM()
			{
				User = await _unitOfWork.UserRepository.GetAsync(u => u.Id == id),
				Roles = _roleManager.Roles.Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Name
				}).ToList()
			};
			return View(userVM);
		}
		[HttpPost]
		public async Task<IActionResult> RoleManagement(UserVM userVM)
		{
			ApplicationUser user = await _unitOfWork.UserRepository.GetAsync(u => userVM.User.Id == u.Id);
			string oldRole =_userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();
			if (userVM.User.Role != oldRole)
			{
				_userManager.RemoveFromRoleAsync(user, oldRole).GetAwaiter().GetResult();
				_userManager.AddToRoleAsync(user, userVM.User.Role).GetAwaiter().GetResult();
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Delete(string id)
		{
			var user = await _unitOfWork.UserRepository.GetAsync(u => u.Id == id);
			return View(user);
		}
		[HttpPost,ActionName("Delete")]
		public async Task<IActionResult> DeletePOST(string id)
		{
			var user= await _unitOfWork.UserRepository.GetAsync(u=>u.Id ==id);
			await _unitOfWork.UserRepository.DeleteAsync(user);
			_unitOfWork.Save();
			return RedirectToAction("Index");
		}
	}
}
