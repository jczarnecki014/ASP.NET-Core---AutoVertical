using AutoVertical_Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutoVertical_web.ViewComponents.UserPanelContainer
{
    public class AdvertisementTab:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(UserPanelVM userPanel)
        {
            return View();
        }
    }
}
