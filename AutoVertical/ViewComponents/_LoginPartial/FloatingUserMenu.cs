using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoVertical_web.ViewComponents.LoginPartial
{
    public class FloatingUserMenu : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public FloatingUserMenu(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            ApplicationUser user = _unitOfWork.applicationUser.GetFirstOfDefault( u=>u.Id == userId );
            return View(user);
        }
    }
}
