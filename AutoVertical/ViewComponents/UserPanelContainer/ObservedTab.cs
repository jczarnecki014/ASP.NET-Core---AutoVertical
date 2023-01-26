using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace AutoVertical_web.ViewComponents.UserPanelContainer
{
    public class ObservedTab:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservedTab(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(UserPanelVM userPanel)
        {
            string LoggedUser = userPanel.User.Id;

            //Get followed vehicles
            IEnumerable<UserFolowedVehicles> userFolowedVehicles =  _unitOfWork.userFollowedVehicle.GetAll(u=>u.UserId == LoggedUser,includeProperties:"Vehicle");

            //Load images for this vehicles and set its to announcement model

            List<Announcement> announcements = new List<Announcement>();

            foreach(var element in userFolowedVehicles)
            {
                Announcement announcement = new Announcement
                {
                    vehicle = element.Vehicle,
                    images = _unitOfWork.gallery.GetAll(u=>u.VehicleId == element.VehicleId).ToList()
                };
                announcements.Add(announcement);
            }

            return View(announcements);
        }
    }
}
