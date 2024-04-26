using System.Diagnostics;
using JetHealth.Data.Repository.IRepository;
using JetHealth.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using JetHealth.Models;
using Microsoft.AspNetCore.Authorization;

namespace JetHealth.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var treatments = await _unitOfWork.TreatmentRepository.GetAllAsync(includeProperties: "TreatmentImages,TreatmentDescription,TreatmentProcedures");
            HomeVM homeVM = new HomeVM
            {
                request = new Request(),
                Treatments = treatments
            };
            if (User.Identity.IsAuthenticated)
            {
                var user = await _unitOfWork.UserRepository.GetAsync(u => u.Email == User.Identity.Name);
                homeVM.request.PhoneNumber = user.PhoneNumber;
                homeVM.request.Name = $"{user.FirstName} {user.LastName}";
            }
            return View(homeVM);
        }
        [HttpPost]
		public async Task<IActionResult> Index(Request request)
		{
			if (ModelState.IsValid)
			{
				await _unitOfWork.RequestRepository.AddAsync(request);
				_unitOfWork.Save();
				TempData["success"] = "Заявку подано!";
			}
			else
			{
				TempData["error"] = "Щось пішло не так";
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Details(int id)
        {
			var treatment = await _unitOfWork.TreatmentRepository.GetAsync(u=>u.Id==id,includeProperties: "TreatmentImages,TreatmentDescription,TreatmentProcedures");
			return View(treatment);
		}
        public async Task<IActionResult> ClinicInfo()
        {
            if (User.Identity.IsAuthenticated)
            {
				var user = await _unitOfWork.UserRepository.GetAsync(u => u.Email == User.Identity.Name);
                Review review = new Review
                {
                    Name = $"{user.FirstName} {user.LastName}"
                };
                return View(review);
			}

			return View();
        }
        [Authorize]
        [HttpPost]
		public async Task<IActionResult> ClinicInfo(Review review)
		{
			if (ModelState.IsValid)
			{
				await _unitOfWork.ReviewRepository.AddAsync(review);
				_unitOfWork.Save();
				TempData["success"] = "Відгук надіслано!";
			}
			else
			{
				TempData["error"] = "Щось пішло не так";
			}
			return RedirectToAction("Index");
		}
    }
}
