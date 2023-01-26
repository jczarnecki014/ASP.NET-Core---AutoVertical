using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using AutoVertical_Utility.FileAcces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public UserProfileController(IUnitOfWork db,IWebHostEnvironment webHostEnvironment) 
        {
            _db = db;
            _WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(string tab,object? optionalArg)
        {
            TempData["HideHeaderAndFooter"] = true;
            UserPanelVM userPanel = new UserPanelVM();
            userPanel.Tab = tab;
            if(optionalArg !=null)
            {
                userPanel.OptionalArg = optionalArg;
            }

            //get user ID
                var claimUser = (ClaimsIdentity)User.Identity;
                var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
                string LoggedUser = claim.Value;
                userPanel.User = _db.applicationUser.GetFirstOfDefault(u=>u.Id==LoggedUser);
             return View(userPanel);
 
        }
        public IActionResult UpdateUser(UserPanelVM userPanelVM,IFormFile? file)
        {
            if(file != null)
            {
                string wwwRoot = _WebHostEnvironment.WebRootPath;
                IFileAcces fileAccess = new FileAcces(file,wwwRoot,$"/Users/{userPanelVM.User.Id}/Avatar/",DefaultName: "Avatar" );
                string AvatarFilePath = fileAccess.Create();
                userPanelVM.User.AvatarSrc = AvatarFilePath;
            }
            _db.applicationUser.Update(userPanelVM.User);
            _db.Save();
            return RedirectToAction("Index",new {tab = "DashboardTab"});
        }

        [HttpPost]
        [Authorize]
        public IActionResult FollowVehicle(Vehicle vehicle)
        {
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
            string LoggedUser = claim.Value;

            ///<summary
            /// Check if youser follow this vehicle already
            /// If true - show every followed vehicle
            /// If false - Add new vehicle to db before redirect
            ///</sumary>
            UserFolowedVehicles checkFollowed = _db.userFollowedVehicle.GetFirstOfDefault(u=>u.UserId == LoggedUser && u.VehicleId == vehicle.Id);
            if(checkFollowed != null)
            {
                return RedirectToAction("Index",new {tab = "ObservedTab"});
            }

            UserFolowedVehicles userFolowedVehicles = new UserFolowedVehicles
            {
                UserId = LoggedUser,
                VehicleId = vehicle.Id,
            };
            Notyfications notyfications = new Notyfications 
            {
                UserId = vehicle.UserId,
                Event = "NewFollow",
                UserOfEventId = LoggedUser
            };
            _db.userFollowedVehicle.Add(userFolowedVehicles);
            _db.notyfications.Add(notyfications);

            _db.Save();
            return RedirectToAction("Index",new {tab = "ObservedTab"});
        }
    }
}
