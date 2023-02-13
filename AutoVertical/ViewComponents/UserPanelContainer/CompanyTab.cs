using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace AutoVertical_web.ViewComponents.UserPanelContainer
{
    public class CompanyTab:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyTab(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(UserPanelVM userPanel)
        {

            //Get currently requested/logged user
            ApplicationUser user = userPanel.User;



            if(user.CompanyId != null)
            {
                //Load every users belonging to this same company as requested user
                List<ApplicationUser> members = _unitOfWork.applicationUser.GetAll(u=>u.CompanyId == user.CompanyId).ToList();

                //Count sold vehicles of every users belonging to this same company as requested user
                int? soldVehicles = 0;
                foreach(ApplicationUser member in members) 
                {
                    if(member.SoldVehicles != null)
                    {
                        soldVehicles += member.SoldVehicles;
                    }
                }

                //Create companyVM model
                CompanyVM companyVM = new CompanyVM
                {
                    members = members,
                    companyAdverts = _unitOfWork.vehicle.GetAll(u=>u.User.CompanyId== user.CompanyId,includeProperties:"User", Expired:true).ToList(),
                    companyAdvertisements = _unitOfWork.advertisement.GetAll(u=>u.User.CompanyId == user.CompanyId,includeProperties:"User").ToList(),
                    CompanysInvitations = _unitOfWork.companyInvitations.GetAll(u => u.CompanyId == user.CompanyId,includeProperties:"User").ToList(),
                    CurrentUser = user,
                    SoldVehicles = soldVehicles
                };
                return View(companyVM);
            }
            else
            {
                if(userPanel.OptionalArg == "Search")
                {
                    ViewBag.search = true;
                }
                CompanyVM companyVM = new CompanyVM
                {
                    CurrentUser = user,
                };
                return View(companyVM);
            }


        }
    }
}
