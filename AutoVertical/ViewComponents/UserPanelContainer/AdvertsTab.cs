using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace AutoVertical_web.ViewComponents.UserPanelContainer
{
    public class AdvertsTab:ViewComponent
    {
        private readonly IUnitOfWork _db;
        public AdvertsTab(IUnitOfWork db)
        {
            _db= db;
        }
        public async Task<IViewComponentResult> InvokeAsync(UserPanelVM userPanel)
        {
            string userId = userPanel.User.Id;

            //get user vehicles
                List<Vehicle> vehicles = _db.vehicle.GetAll(u=>u.UserId==userId,Expired:true).ToList();

            switch(userPanel.OptionalArg)
            {
                case "ShowActive":
                    vehicles = vehicles.Where(u=>u.ExpireDate.CompareTo(DateTime.Now.Date)>=0).ToList();
                break;
                case "ShowExpired":
                    vehicles = vehicles.Where(u=>u.ExpireDate.CompareTo(DateTime.Now.Date)<0).ToList();
                break;
                case "ShowMentioned":
                    vehicles = vehicles.Where(u=>u.MentionTime.CompareTo(DateTime.Now.Date)>=0).ToList();
                break;
                default:
                break;
            }

            //get user vehicles
            return View(vehicles);
        }
    }
}
