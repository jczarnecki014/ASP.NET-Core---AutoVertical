using AutoVertical_Data;
using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using AutoVertical_Utility.FileAcces;
using AutoVertical_Utility.Roles;
using AutoVertical_Utility.UserDirectories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    
    public class CompanyController : Controller
    {   
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _WebHostEnviroment;
        private readonly DbAccess _test;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment,DbAccess test)
        {
            _unitOfWork = unitOfWork;
            _WebHostEnviroment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult CreateCompany()
        {
        return View();
        }

        [HttpPost]
        public IActionResult CreateCompany(Company userCompany, IFormFile file)
        {

            string wwwRoot = _WebHostEnviroment.WebRootPath;

            IFileAcces fileAcces = new FileAcces(file,wwwRoot,"\\CompanysLogo\\");
            if(!fileAcces.FileState.isValid)
            {
                ModelState.AddModelError("FileValidation","File is not valid");
            }
            else
            {
                string FilePath = fileAcces.Create();
                userCompany.LogoSrc = FilePath;
            }
        
            if(ModelState.IsValid)
            {
                _unitOfWork.company.Add(userCompany);
                _unitOfWork.Save();

                //Add company id to user record

                var claimUser = (ClaimsIdentity)User.Identity;
                var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
                string LoggedUser = claim.Value;

                ApplicationUser loggedUser = _unitOfWork.applicationUser.GetFirstOfDefault(u=>u.Id==LoggedUser);
                loggedUser.CompanyId = userCompany.id;

                _unitOfWork.Save();

                //Set role for user (if user estabilish own bussines he are getting "ownerRole"

                _unitOfWork.companyRoles.Add(new CompanyRoles
                {
                    UserId = LoggedUser,
                    CompanyRole = Roles.Role_Company_Owner,
                });

                _unitOfWork.Save();

                return RedirectToAction("Index","UserProfile",new{tab="CompanyTab"});
            }
            else
            {
                return View(userCompany);
            }
        
        }


        #region API

            public IActionResult GetCompanyList()
            {
                List<Company> companyList = _unitOfWork.company.GetAll().ToList();
                return Json(companyList);
            }

        #endregion
    }
}