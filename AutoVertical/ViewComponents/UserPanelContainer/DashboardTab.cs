using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutoVertical_web.ViewComponents
{
    public class DashboardTab : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardTab(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(UserPanelVM userPanel)
        {
            UserPanelDasboardVM viewModel = new UserPanelDasboardVM
            {
                User = userPanel.User,
                ActiveAdvertCount = _unitOfWork.vehicle.GetAll(u=>u.UserId == userPanel.User.Id).Count(),
                ActiveAdvertisementCount = _unitOfWork.advertisement.GetAll(u=>u.UserId == userPanel.User.Id).Count(),
                userCompany = _unitOfWork.company.GetFirstOfDefault(u=>u.id == userPanel.User.CompanyId),
            };
            return View(viewModel);
        }
    }
}
