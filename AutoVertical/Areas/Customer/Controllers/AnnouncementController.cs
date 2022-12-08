using Microsoft.AspNetCore.Mvc;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AnnouncementController : Controller
    {
        public IActionResult CreateAnnouncement()
        {
        return View();
        }
    }
}
