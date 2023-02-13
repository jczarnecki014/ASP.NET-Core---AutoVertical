
using AutoVertical_Data;
using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using AutoVertical_Utility.FileAcces;
using AutoVertical_Utility.Roles;
using AutoVertical_Utility.UserDirectories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Security.Claims;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
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


                //Set role for user (if user estabilish own bussines he are getting "ownerRole"

                loggedUser.CompanyRole = Roles.Role_Company_Owner;

                _unitOfWork.Save();

                return RedirectToAction("Index","UserProfile",new{tab="CompanyTab"});
            }
            else
            {
                return View(userCompany);
            }
        
        }
        [HttpPost]
        public IActionResult LeaveCompany() 
        {
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
            string LoggedUser = claim.Value;

            ApplicationUser user = _unitOfWork.applicationUser.GetFirstOfDefault(u=>u.Id == LoggedUser,includeProperties:"Company");
            
            if(user.CompanyId == null)
            {
                NotFound("Sory but we haven't found any company in related with you");
            }

            //If user are owner a company and he want to leave it, remove company

            if(user.CompanyRole == Roles.Role_Company_Owner)
            {
                //Fire employees
                List<ApplicationUser> companyMembers = _unitOfWork.applicationUser.GetAll(u=>u.CompanyId == user.CompanyId).ToList();
                foreach(ApplicationUser companyMember in companyMembers) 
                {
                    _unitOfWork.applicationUser.RemoveUserFromCompany(companyMember);
                }
                //Delete company

                string logoPath = _WebHostEnviroment.WebRootPath+user.Company.LogoSrc;
                IFileAcces.Delete(logoPath);
                
                _unitOfWork.company.Remove(user.Company);  
                
            }
            else if(user.CompanyRole == Roles.Role_Company_Employer) 
            {
                _unitOfWork.applicationUser.RemoveUserFromCompany(user);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index","UserProfile", new {tab = "CompanyTab"});
        }

        [HttpPost]
        public IActionResult EditCompany(CompanyVM companyVM,IFormFile? file)
        {
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
            string LoggedUser = claim.Value;

            ApplicationUser loggedUser = _unitOfWork.applicationUser.GetFirstOfDefault(u=>u.Id == LoggedUser,includeProperties:"Company");

            if(loggedUser.CompanyId != companyVM.CurrentUser.Company.id || loggedUser.CompanyRole != Roles.Role_Company_Owner ) 
            { 
                return NotFound("You aren't member of this company or you haven't permissions to do it");
            }

            if(file !=null)
            {
                var wwwRootPath = _WebHostEnviroment.WebRootPath;
                IFileAcces fileAcces = new FileAcces(file,wwwRootPath,"/CompanysLogo");

                if(!fileAcces.FileState.isValid)
                {
                    TempData["error"] = "Invalid file !";
                    return RedirectToAction("Index","UserProfile", new {tab = "CompanyTab"});
                }

                var PreviousLogoPath = loggedUser.Company.LogoSrc;

                IFileAcces.Delete(wwwRootPath+PreviousLogoPath);

                var newLogoPath = fileAcces.Create();
                
                companyVM.CurrentUser.Company.LogoSrc = newLogoPath;

            }

            _unitOfWork.company.Update(companyVM.CurrentUser.Company);
            _unitOfWork.Save();
            return RedirectToAction("Index","UserProfile", new {tab = "CompanyTab"});

        }

        public IActionResult AddUserToCompany(int invitationId)
            {
                CompanysInvitations companyInvitations = _unitOfWork.companyInvitations.GetFirstOfDefault(u=>u.Id == invitationId,includeProperties:"User");

                if(companyInvitations == null)
                {
                    return NotFound();
                }

                var loggedUserID = (string?) User.FindFirst(ClaimTypes.NameIdentifier).Value;  

                ApplicationUser loggedUser = _unitOfWork.applicationUser.GetFirstOfDefault(u=> u.Id == loggedUserID);

                if(!(loggedUser.CompanyId == companyInvitations.CompanyId && loggedUser.CompanyRole == Roles.Role_Company_Owner))
                {
                    return NotFound();
                }


                _unitOfWork.applicationUser.AddUserToCompany(companyInvitations.User,companyInvitations.CompanyId,Roles.Role_Company_Employer);

                //If user has been added to company, remove every user invitation to avoid adding user by other companys

                IEnumerable<CompanysInvitations>userInvitations = _unitOfWork.companyInvitations.GetAll(u=>u.UserId == companyInvitations.UserId);
                _unitOfWork.companyInvitations.RemoveRange(userInvitations);
                _unitOfWork.Save();

                return RedirectToAction("Index","UserProfile", new {tab = "CompanyTab"});
            }

        public IActionResult RemoveInvitation(int invitationId)
            {
                CompanysInvitations companyInvitations = _unitOfWork.companyInvitations.GetFirstOfDefault(u=>u.Id==invitationId,includeProperties:"User");

                if(companyInvitations == null)
                {
                    return NotFound();
                }

                var loggedUserID = (string?) User.FindFirst(ClaimTypes.NameIdentifier).Value;  

                ApplicationUser loggedUser = _unitOfWork.applicationUser.GetFirstOfDefault(u=> u.Id == loggedUserID);

                if(!(loggedUser.CompanyId == companyInvitations.CompanyId && loggedUser.CompanyRole == Roles.Role_Company_Owner))
                {
                    return NotFound();
                }


                _unitOfWork.companyInvitations.Remove(companyInvitations);
                _unitOfWork.Save();

                return RedirectToAction("Index","UserProfile", new {tab = "CompanyTab"});
            }

            public IActionResult FireUserFromCompany(string userToFireId)
            {
                var LoggedUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationUser LogedUser = _unitOfWork.applicationUser.GetFirstOfDefault(u=>u.Id == LoggedUserId);

                ApplicationUser userToFire = _unitOfWork.applicationUser.GetFirstOfDefault(u=>u.Id == userToFireId);
                
                if(!(LogedUser.CompanyId == userToFire.CompanyId && LogedUser.CompanyRole == Roles.Role_Company_Owner))
                {
                    return StatusCode(403,"No access");
                }

                _unitOfWork.applicationUser.RemoveUserFromCompany(userToFire);
                _unitOfWork.Save();
                return RedirectToAction("Index","UserProfile", new {tab = "CompanyTab"});
            }

        #region API

            public IActionResult GetCompanyList()
            {
                List<Company> companyList = _unitOfWork.company.GetAll().ToList();
                return Json(companyList);
            }

            [HttpPost]
            public IActionResult CompanyInvitations(int CompanyId)
            {
                var claimUser = (ClaimsIdentity)User.Identity;
                var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
                string LoggedUser = claim.Value;

                ApplicationUser user = _unitOfWork.applicationUser.GetFirstOfDefault(u=> u.Id == LoggedUser);

                if(user.CompanyId != null)
                {
                    return BadRequest("User is already employed in some company");
                }
                if(!_unitOfWork.company.Exist(u=>u.id == CompanyId))
                {
                    return BadRequest("Company with that ID doesn't exist");
                }
                if(_unitOfWork.companyInvitations.Exist(u=>u.UserId == user.Id && u.CompanyId == CompanyId))
                {
                    return BadRequest("Invitation alredy exist");
                }

                _unitOfWork.companyInvitations.Add(
                    new CompanysInvitations
                    {
                        UserId = user.Id,
                        CompanyId = CompanyId,
                    }
                );

                _unitOfWork.Save();

                return Ok("Invitation has been sent to the company");

            }

        #endregion
    }
}