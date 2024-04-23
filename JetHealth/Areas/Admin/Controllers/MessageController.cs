using JetHealth.Data.Repository.IRepository;
using JetHealth.Models.Abstract;
using JetHealth.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.ROLEAdmin}")]
    public class MessageController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        public MessageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
		{
			List<Message> messages =(await _unitOfWork.RequestRepository.GetAllAsync()) as List<Message>;
			messages.AddRange((await _unitOfWork.ReviewRepository.GetAllAsync()) as List<Message>);
			return View(messages);
		}
		public IActionResult DeleteReview(int id)
		{
			return View();
		}
		public IActionResult DeleteRequest(int id)
		{
			return View();
		}
	}
}
