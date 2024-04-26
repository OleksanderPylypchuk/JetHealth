using System.Text;
using JetHealth.Data.Repository.IRepository;
using JetHealth.Models;
using JetHealth.Models.Abstract;
using JetHealth.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
			List<Message> messages=
			[
				.. await _unitOfWork.RequestRepository.GetAllAsync(),
				.. await _unitOfWork.ReviewRepository.GetAllAsync(),
			];
			return View(messages);
		}

		

		public async Task<IActionResult> DeleteReview(int id)
		{
			var reviewToDelete=await _unitOfWork.ReviewRepository.GetAsync(u=>u.Id == id);
			if (reviewToDelete != null)
			{
				await _unitOfWork.ReviewRepository.DeleteAsync(reviewToDelete);
				_unitOfWork.Save();
				TempData["success"] = "Відгук видалено успішно!";
			}
			else
			{
				TempData["error"] = "Щось пішло не так";
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> DeleteRequest(int id)
		{
			var requestToDelete = await _unitOfWork.RequestRepository.GetAsync(u => u.Id == id);
			if (requestToDelete != null)
			{
				await _unitOfWork.RequestRepository.DeleteAsync(requestToDelete);
				_unitOfWork.Save();
				TempData["success"] = "Заявку видалено успішно!";
			}
			else
			{
				TempData["error"] = "Щось пішло не так";
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> DownloadMessages()
		{
			List<Message> messages =
			[
				.. await _unitOfWork.RequestRepository.GetAllAsync(),
				.. await _unitOfWork.ReviewRepository.GetAllAsync(),
			];
			var jsonData=JsonConvert.SerializeObject(messages);
			byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
			string contentType = "application/json";
			string fileName = "messages.json";
			return File(bytes, contentType, fileName);
		}
		public async Task<IActionResult> DownloadRequests()
		{
			var requests = await _unitOfWork.RequestRepository.GetAllAsync();
			var jsonData = JsonConvert.SerializeObject(requests);
			byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
			string contentType = "application/json";
			string fileName = "requests.json";
			return File(bytes, contentType, fileName);
		}
		public async Task<IActionResult> DownloadReviews()
		{
			var reviews = await _unitOfWork.ReviewRepository.GetAllAsync();
			var jsonData = JsonConvert.SerializeObject(reviews);
			byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
			string contentType = "application/json";
			string fileName = "reviews.json";
			return File(bytes, contentType, fileName);
		}
	}
}
