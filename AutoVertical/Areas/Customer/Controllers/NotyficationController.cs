using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class NotyficationController : Controller
    {
    
        private readonly IUnitOfWork _unitOfWork;
        public NotyficationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region API

        public IActionResult GetUserNotyfications() 
        {
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
            string LoggedUser = claim.Value;

            List<Notyfications> notyfication = _unitOfWork.notyfications.GetAll(u=>u.UserId == LoggedUser,includeProperties:"UserOfEvent").ToList();

            return Json(notyfication); 
        }

        [HttpPost]
        public IActionResult RemoveUserNotyfication(int id)
        {
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
            string LoggedUser = claim.Value;

            Notyfications notyfication = _unitOfWork.notyfications.GetFirstOfDefault(u=>u.Id == id);

            if(notyfication.UserId != LoggedUser)
            {
                return NotFound();
            }
            
            _unitOfWork.notyfications.Remove(notyfication);
            _unitOfWork.Save();
            return Json("succes");
        }

        #endregion
    }
}
