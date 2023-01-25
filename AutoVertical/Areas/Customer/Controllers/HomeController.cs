using AutoVertical.Models;
using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StartSellingMenu()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}