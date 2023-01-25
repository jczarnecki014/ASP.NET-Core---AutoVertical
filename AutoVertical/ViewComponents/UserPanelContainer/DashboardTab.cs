using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutoVertical_web.ViewComponents
{
    public class DashboardTab : ViewComponent
    {
        private readonly IUnitOfWork _db;
        public DashboardTab(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(UserPanelVM userPanel)
        {
            UserPanelDasboardVM viewModel = new UserPanelDasboardVM
            {
                User = userPanel.User,
                ActiveAdvertCount = _db.vehicle.GetAll(u=>u.UserId == userPanel.User.Id).Count(),
                ActiveAdvertisementCount = _db.advertisement.GetAll(u=>u.UserId == userPanel.User.Id).Count(),
            };
            return View(viewModel);
        }
    }
}
