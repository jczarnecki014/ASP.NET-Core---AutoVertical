using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutoVertical_web.ViewComponents.UserPanelContainer
{
    public class AdvertisementTab:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdvertisementTab(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(UserPanelVM userPanel)
        {
            UserPanelAdvertisementVM advertisementVM = new UserPanelAdvertisementVM
            {
                AdvertisementToShow = _unitOfWork.advertisement.GetAll(u=>u.UserId == userPanel.User.Id,Expired: true, ActiveInFuture: true )
            };
            return View(advertisementVM);
        }
    }
}
