﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JetHealth.Utility;
using JetHealth.Models;
using JetHealth.Data.Repository.IRepository;
using System.IO;
using JetHealth.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace JetHealth.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles =$"{SD.ROLEAdmin},{SD.ROLEDoctor}")]
	public class TreatmentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        public TreatmentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _userManager= userManager;
        }
        public async Task<IActionResult> Index()
		{
			List<Treatment> treatments =_unitOfWork.TreatmentRepository.GetAllAsync(includeProperties: "TreatmentImages,TreatmentDescription,TreatmentProcedures,ApplicationUser")
                .GetAwaiter().GetResult().ToList();
			return View(treatments);
		}
		public async Task<IActionResult> Upsert(int? id)
		{
			TreatmentVM treatment=new();

            if (id != null&&id!=0)
			{
                treatment.Treatment = _unitOfWork.TreatmentRepository.GetAsync(u=>u.Id==id,includeProperties: "TreatmentImages,TreatmentDescription,TreatmentProcedures").GetAwaiter().GetResult();
            }
			else
			{
                treatment.Treatment = new Treatment()
				{
                     TreatmentDescription = new(),
                     TreatmentImages = new(),
                     TreatmentProcedures = new()
                };
			}
            var users = await _userManager.GetUsersInRoleAsync(SD.ROLEDoctor);
            treatment.Users = users.Select(x => new SelectListItem
            {
                Text = x.Email,
                Value = x.Id
            });
			return View(treatment);
		}
		[HttpPost]
		public async Task<IActionResult> Upsert(TreatmentVM treatmentVM,List<IFormFile> files)
		{
            if (ModelState.IsValid)
            {
                string result;
                Treatment treatment;
                if (treatmentVM.Treatment.Id == 0)
                {
                    await _unitOfWork.TreatmentRepository.AddAsync(treatmentVM.Treatment);
                    _unitOfWork.Save();
                    treatment = _unitOfWork.TreatmentRepository.GetLast();
                    result = "Cтворено новий напрям";
                }
                else
                {
                    treatment = treatmentVM.Treatment;
                    result = "Оновлено напрям";
                }
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
                {
                    foreach (IFormFile file in files)
                    {
                        string extension = Path.GetExtension(file.FileName);

                        if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                        {
                            continue;
                        }
                        string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string treatmentPath = @"images\treatment\treatment-" + treatment.Id;
                        string finalPath = Path.Combine(wwwRootPath, treatmentPath);

                        if (!Directory.Exists(finalPath))
                        {
                            Directory.CreateDirectory(finalPath);
                        }
                        using (var filestream = new FileStream(Path.Combine(finalPath, filename), FileMode.Create))

                        {
                            file.CopyTo(filestream);
                        }

                        TImage tImage = new TImage()
                        {
                            ImgUrl = @"\" + treatmentPath + @"\" + filename,
                            TreatmentId = treatment.Id
                        };

                        if (treatment.TreatmentImages == null)
                        {
                            treatment.TreatmentImages = new List<TImage>();
                        }

                        treatment.TreatmentImages.Add(tImage);
                        await _unitOfWork.ImageRepository.AddAsync(tImage);
                    }
                }

                if (treatment.TreatmentDescription.Id != 0)
                {
                    var description = treatment.TreatmentDescription;
                    description.TreatmentId = treatment.Id;
                    _unitOfWork.DescriptionRepository.Update(description);
                    _unitOfWork.Save();
                    treatment.TreatmentDescriptionId = description.Id;
                }
                else
                {
                    var description = await _unitOfWork.DescriptionRepository.GetAsync(u => u.TreatmentId == treatment.Id);
                    if (description.Description != treatment.TreatmentDescription.Description)
                    {
                        description.Description = treatment.TreatmentDescription.Description;

                    }
                    treatment.TreatmentDescription = description;
                }

                _unitOfWork.TreatmentRepository.Update(treatment);
                _unitOfWork.Save();
                TempData["success"] = result;
                return RedirectToAction("Index"); 
            }
			else
			{
				var users = await _userManager.GetUsersInRoleAsync(SD.ROLEDoctor);
				treatmentVM.Users = users.Select(x => new SelectListItem
				{
					Text = x.Email,
					Value = x.Id
				});
				return View(treatmentVM);
            }
		}
		public async Task<IActionResult> Delete(int id)
		{
			var treatment = await _unitOfWork.TreatmentRepository.GetAsync(u => u.Id == id,includeProperties: "TreatmentImages,TreatmentDescription,TreatmentProcedures");
			if (treatment == null)
			{
                return RedirectToAction("Index");
            }
			return View(treatment);
		}
		[HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var treatment = await _unitOfWork.TreatmentRepository.GetAsync(u => u.Id == id, includeProperties: "TreatmentImages,TreatmentDescription,TreatmentProcedures");
            if (treatment == null)
            {
                return RedirectToAction("Index");
            }
            var decription =await  _unitOfWork.DescriptionRepository.GetAsync(u => u.TreatmentId == id && u.Id == treatment.TreatmentDescriptionId);
			await _unitOfWork.DescriptionRepository.DeleteAsync(decription);
			_unitOfWork.Save();
			await _unitOfWork.TreatmentRepository.DeleteAsync(treatment);
			_unitOfWork.Save();
            TempData["success"] = "Успішно видалено напрям";
			return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpsertTProcedure(int? id)
		{
			TProcedure tProcedure;
			if (id != null)
			{
                tProcedure =await _unitOfWork.ProcedureRepository.GetAsync(u => u.Id == id);
			}
			else
			{
                tProcedure = new();
            }
			tProcedure.Treatments = (await _unitOfWork.TreatmentRepository.GetAllAsync()).Select(x => new SelectListItem()
			{
				Text = x.TreatmentName,
				Value = x.Id.ToString()
			});
			return View(tProcedure);
		}
        [HttpPost]
		public async Task<IActionResult> UpsertTProcedure(TProcedure procedure)
        {
            if(ModelState.IsValid)
            {
                if (procedure.Id == 0)
                {
                    await _unitOfWork.ProcedureRepository.AddAsync(procedure);
                }
                else
                {
                    _unitOfWork.ProcedureRepository.Update(procedure);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
			procedure.Treatments = (await _unitOfWork.TreatmentRepository.GetAllAsync()).Select(x => new SelectListItem()
			{
				Text = x.TreatmentName,
				Value = x.Id.ToString()
			});
			return View(procedure);

		}

		public async Task<IActionResult> DeleteTProcedure(int? id)
        {
			var tprocedure = _unitOfWork.ProcedureRepository.GetAsync(u=>u.Id==id).GetAwaiter().GetResult();
			if (tprocedure != null)
			{
                await _unitOfWork.ProcedureRepository.DeleteAsync(tprocedure);
                _unitOfWork.Save();
            }
			return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTImage(int? id)
        {
			var image = await _unitOfWork.ImageRepository.GetAsync(u => u.Id == id);
			int? treatmwntid = image.TreatmentId;
			if (image != null)
			{
				if (!string.IsNullOrEmpty(image.ImgUrl))
				{
					string imageurl = Path.Combine(_webHostEnvironment.WebRootPath, image.ImgUrl.TrimStart('\\'));
					if (System.IO.File.Exists(imageurl))
					{
						System.IO.File.Delete(imageurl);
					}

				}
                await _unitOfWork.ImageRepository.DeleteAsync(image);
				_unitOfWork.Save();
				TempData["success"] = "Image deleted successfully";
			}
			return RedirectToAction(nameof(Upsert), new { id = treatmwntid });
		}
    }
}
