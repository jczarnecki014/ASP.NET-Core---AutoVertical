using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using AutoVertical_Utility.FileAcces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
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
        public IActionResult Configurator()
        {
        return View();
        }
        
        [HttpPost]
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
    }
}
