using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.Viewmodels;
using AutoVertical_Utility.FileAcces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;  

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AnnouncementController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        [BindProperty]
        public AnnoncementVM input { get; set; }
        public AnnouncementController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment) 
        {
            _UnitOfWork = unitOfWork;
            _WebHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult CreateAnnouncement()
        {
            return View();
        }
        [HttpPost,ActionName("CreateAnnouncement")]
        [ValidateAntiForgeryToken]
        public IActionResult AddAnnouncement(IFormFile[] files)
        {
            //Customize ModelState for specific vehicle
            switch (input.vehicle.VehicleType)
            {
                    case "car":
                        ModelState.Remove("truck.NumberOfAxles");
                        ModelState.Remove("truck.PermissibleGrossWeight");
                        ModelState.Remove("truck.AllowPackage");
                    break;

                    case "truck":
                        ModelState.Remove("car.NumberOfDoor");
                        ModelState.Remove("car.NumberOfSeats");
                        ModelState.Remove("vehicle.Drive");
                    break;

                    case "motorcycle":
                        ModelState.Remove("truck.NumberOfAxles");
                        ModelState.Remove("truck.PermissibleGrossWeight");
                        ModelState.Remove("truck.AllowPackage");
                        ModelState.Remove("car.NumberOfDoor");
                        ModelState.Remove("car.NumberOfSeats");
                        ModelState.Remove("vehicle.Drive");
                    break;
            }

            //Check images before db connection
            IFileAcces fileAcces;
            string wwwRootPath = _WebHostEnvironment.WebRootPath;

            foreach(var file in files) 
            {
                fileAcces = new FileAcces(file,wwwRootPath);

                if(!fileAcces.FileState.isValid)
                {
                   ModelState.AddModelError("FileError","One or more files is invalid");
                   TempData["Error"] = "File is incorrect";
                   break;
                }
            }


            //If model state is valid add vehicle to db
            if(ModelState.IsValid && files is not null)
            {
                int id;
                //Choose specific vehicle
                switch (input.vehicle.VehicleType)
                {
                    case "car":
                        _UnitOfWork.car.Add(input.car);
                        _UnitOfWork.Save();
                        id = input.car.Id;
                        input.vehicle.CarId = id;
                    break;

                    case "truck":
                        _UnitOfWork.truck.Add(input.truck);
                        _UnitOfWork.Save();
                        id = input.truck.Id;
                        input.vehicle.TruckId = id;
                    break;

                    case "motorcycle":
                        _UnitOfWork.motorcycle.Add(input.motorcycle);
                        _UnitOfWork.Save();
                        id = input.motorcycle.Id;
                        input.vehicle.MotorcycleId = id;
                    break;
                }
                _UnitOfWork.vehicle.Add(input.vehicle);
                _UnitOfWork.Save();
                
                //Save user images in server
                foreach(var file in files) 
                {
                    fileAcces = new FileAcces(file,wwwRootPath);
                    string fileName = fileAcces.Create();
                    ImgGallery newImg = new ImgGallery()
                    {
                        Name= fileName,
                        VehicleId = input.vehicle.Id
                    };
                    _UnitOfWork.gallery.Add(newImg);
                }
                _UnitOfWork.Save();
                TempData["Success"] = "New announcement was added";
                return View();
            }
            else{
                return View(input);
            }
        }

        [HttpGet]
        public IActionResult ShowAnnouncement()
        {
            return View();
        }
    }
}
