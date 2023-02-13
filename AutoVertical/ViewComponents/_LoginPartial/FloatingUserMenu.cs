using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
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
            ApplicationUser appUser = _unitOfWork.applicationUser.GetFirstOfDefault( u=>u.Id == userId );
            FloatingUserMenuVm viewModel = new FloatingUserMenuVm()
            {
                user = appUser,
                userCompany = _unitOfWork.company.GetFirstOfDefault( u=>u.id == appUser.CompanyId ),
                userNotyficationsCount = _unitOfWork.notyfications.GetAll(u=>u.UserId== appUser.Id).Count()
            };
            return View(viewModel);
        }
    }
}
