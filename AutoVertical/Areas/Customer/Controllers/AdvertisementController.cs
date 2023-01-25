using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using AutoVertical_Utility;
using AutoVertical_Utility.FileAcces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AdvertisementController : Controller
    {
        private readonly IWebHostEnvironment _WebhostEnviroment;
        private readonly IUnitOfWork _unitOfWork;
        public AdvertisementController(IWebHostEnvironment WebhostEnviroment, IUnitOfWork unitOfWork)
        {
            _WebhostEnviroment = WebhostEnviroment;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Configurator()
        {
        ViewBag.LargeAdvertPrice = Options.LargeAdvertisementPricePerDay;
        ViewBag.MediumAdvertPrice = Options.MediumAdvertisementPricePerDay;
        ViewBag.SamllAdvertPrice = Options.SmallAdvertisementPricePerDay;
        return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Configurator(Advertisement userAdvertisement, IFormFile file)
        {
            if(userAdvertisement != null && file != null)
            {
                if(userAdvertisement.ActiveFrom >= userAdvertisement.ActiveTo)
                {
                    ModelState.AddModelError("ActiveTo", "Incorrect data");
                }
                string wwwRoot = _WebhostEnviroment.WebRootPath;

                var claimUser = (ClaimsIdentity)User.Identity;
                var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
                string UserId = claim.Value;

                IFileAcces fileAcces = new FileAcces(file,wwwRoot,$"/Users/{UserId}/Advertisement/");

                if(!fileAcces.FileState.isValid)
                {
                    ModelState.AddModelError("File", "File is not valid");
                }

                if(ModelState.IsValid)
                {
                    string fileName = fileAcces.Create();
                    userAdvertisement.UserId = UserId;
                    userAdvertisement.ImageSrc = fileName;
                    _unitOfWork.advertisement.Add(userAdvertisement);
                    _unitOfWork.Save();
                    return View();
                }
                else
                {
                    return View(userAdvertisement);
                }
            }
            else
            {
                return View(userAdvertisement);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult AdvertisementUpdate(UserPanelAdvertisementVM AdvertisementVM, IFormFile? file)
        {
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
            string LoggedUserId = claim.Value;

            Advertisement userAdvertisement = _unitOfWork.advertisement.GetFirstOfDefault(u=>u.Id == AdvertisementVM.AdvertisementToUpdate.Id);
            if(userAdvertisement.UserId != LoggedUserId)
            {
                return NotFound();
            }

            if(file!=null)
            {
                string wwwRoot = _WebhostEnviroment.WebRootPath;
                IFileAcces fileAcces = new FileAcces(file,wwwRoot,$"""\Users\{LoggedUserId}\Advertisement\""");
                if(fileAcces.FileState.isValid)
                {
                    IFileAcces.Delete(wwwRoot + userAdvertisement.ImageSrc);
                    string newFileName = fileAcces.Create();
                    AdvertisementVM.AdvertisementToUpdate.ImageSrc= newFileName;
                }
            }

            _unitOfWork.advertisement.Update(AdvertisementVM.AdvertisementToUpdate);
            _unitOfWork.Save();
            return RedirectToAction("Index","UserProfile", new {tab="AdvertisementTab"});

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AdvertisementDelete(UserPanelAdvertisementVM AdvertisementVM)
        {
            
            Advertisement advertisement = _unitOfWork.advertisement.GetFirstOfDefault(u=>u.Id==AdvertisementVM.AdvertisementToUpdate.Id);
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
            string LoggedUserId = claim.Value;

            if(advertisement.UserId == LoggedUserId)
            {
                string wwwRoot = _WebhostEnviroment.WebRootPath;
                IFileAcces.Delete(wwwRoot+advertisement.ImageSrc);
                _unitOfWork.advertisement.Remove(advertisement);
                _unitOfWork.Save();
            }

            return RedirectToAction("Index","UserProfile", new {tab="AdvertisementTab"});
        }

        #region Api

        public IActionResult GetAdvertisements(string size)
        {
            List<Advertisement>advertisements = _unitOfWork.advertisement.GetAll(u=>u.Size == size).ToList();
            return Json(advertisements);
        }
        [Authorize]
        public IActionResult GetUserAdvertisement(int id)
        {
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
            string LoggedUserId = claim.Value;
            
            Advertisement userAdvertisement = _unitOfWork.advertisement.GetFirstOfDefault(u=>u.Id == id);

            if(userAdvertisement.UserId != LoggedUserId)
            {
                return NotFound();
            }
            else
            {
                return Json(userAdvertisement);
            }
        }

        #endregion
    }
}
