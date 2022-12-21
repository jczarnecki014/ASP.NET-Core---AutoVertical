using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Utility.FileAcces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AnnouncementController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        [BindProperty]
        public Vehicle vehicle { get; set; }
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
            switch (vehicle.VehicleType)
            {
                    case "car":
                        ModelState.Remove("truck.NumberOfAxles");
                        ModelState.Remove("truck.PermissibleGrossWeight");
                        ModelState.Remove("truck.AllowPackage");
                    break;

                    case "truck":
                        ModelState.Remove("car.NumberOfDoor");
                        ModelState.Remove("car.NumberOfSeats");
                    break;

                    case "motorcycle":
                        ModelState.Remove("truck.NumberOfAxles");
                        ModelState.Remove("truck.PermissibleGrossWeight");
                        ModelState.Remove("truck.AllowPackage");
                        ModelState.Remove("car.NumberOfDoor");
                        ModelState.Remove("car.NumberOfSeats");
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
                switch (vehicle.VehicleType)
                {
                    case "car":
                        _UnitOfWork.car.Add(vehicle.car);
                        _UnitOfWork.Save();
                        vehicle.motorcycle = null;
                        vehicle.truck = null;
                    break;

                    case "truck":
                        _UnitOfWork.truck.Add(vehicle.truck);
                        _UnitOfWork.Save();
                        vehicle.motorcycle = null;
                        vehicle.car = null;
                    break;

                    case "motorcycle":
                        _UnitOfWork.motorcycle.Add(vehicle.motorcycle);
                        _UnitOfWork.Save();
                        vehicle.truck = null;
                        vehicle.car = null;
                    break;
                }
                _UnitOfWork.vehicle.Add(vehicle);
                _UnitOfWork.Save();
                
                //Save user images in server
                foreach(var file in files) 
                {
                    fileAcces = new FileAcces(file,wwwRootPath);
                    string fileName = fileAcces.Create();
                    ImgGallery image = new ImgGallery()
                    {
                        Name= fileName,
                        VehicleId = vehicle.Id
                    };
                    _UnitOfWork.gallery.Add(image);
                }
                _UnitOfWork.Save();
                TempData["Success"] = "New announcement was added";
                return View();
            }
            else{
                return View(vehicle);
            }
        }

        [HttpGet]
        public IActionResult ShowAnnouncement(int id)
        {
            /*Supplies in vehicle record*/
            vehicle = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id == id,includeSpecific:true);

            if(vehicle is null)
            {
                return NotFound();
            }

            /*Gets equimpents witch were checked by user*/
            var specificVehicle = new object();
            if(vehicle.car != null)
            {
                specificVehicle = vehicle.car;
            }
            else if(vehicle.truck != null)
            {
                specificVehicle= vehicle.truck;
            }
            else if(vehicle.motorcycle != null)
            {
                specificVehicle= vehicle.motorcycle;
            }

            List<string> EquipmentList = new List<string>();
            foreach(PropertyInfo prop in specificVehicle.GetType().GetProperties())
            {
                /*It Iterates through all objec propeties and check choose only boolean properties, next to it add to equipment list only properties witch true value */
                if(prop.PropertyType.FullName == "System.Boolean")
                {
                    bool isChecked = (bool)prop.GetValue(specificVehicle);
                    if(isChecked == true)
                    {
                        string[] split =  Regex.Split(prop.Name, @"(^[A-Z][a-z]+)([A-Z][a-z]+)([A-Z]?[a-z]*)([A-Z]?[a-z]*)"); //Because object properties name is camelCase we have to use regex to divde every word before show
                        EquipmentList.Add($"{String.Join(" ",split)}");
                    }
                }
            }
            ViewBag.EquipmentList = EquipmentList;
            return View(vehicle);

        }

        #region GalleryAPI
        [HttpGet]
        public IActionResult GetGallery(int id)
        {
            if(id == 0) 
            {
                return NotFound();
            }
            else{
                var imagesList = _UnitOfWork.gallery.GetAll(u=>u.VehicleId == id);
                return Json(new {data=imagesList});
            }
        }
        #endregion

        #region GetAveragePriceSimilarVehicle
            [HttpGet]
            public IActionResult GetAveragePriceSimilarVehicle(int id)
            {
                if(id == 0) 
                {
                    return NotFound();
                }
                else
                {
                    Vehicle announcementVehicle = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id == id);
                    IEnumerable<AutoVertical_Model.Models.Vehicle> vehicleToCompare = _UnitOfWork.vehicle.GetAll(u=>u.Brand == announcementVehicle.Brand);
                    IEnumerable<AutoVertical_Model.Models.Vehicle> temp;
                    if(vehicleToCompare.Count() > 3)
                    {
                        temp = vehicleToCompare.Where(x=>x.Fuel == announcementVehicle.Fuel);
                       if(temp.Count() > 3)
                       {
                          vehicleToCompare = temp;
                          temp = vehicleToCompare.Where(x=>x.ProductionYear >= announcementVehicle.ProductionYear-3 && x.ProductionYear <=announcementVehicle.ProductionYear+2);
                          if(temp.Count() > 3)
                          {
                                vehicleToCompare=temp;
                                temp = vehicleToCompare.Where(x=>(x.Power >= announcementVehicle.Power-80) && (x.Power <= announcementVehicle.Power+80));
                                if(temp.Count() > 3)
                                {
                                    vehicleToCompare=temp;
                                    temp=vehicleToCompare.Where(x=>(x.Milage >= announcementVehicle.Milage-50000) && (x.Milage <= announcementVehicle.Milage+50000));
                                    if(temp.Count()>3) 
                                    {
                                        vehicleToCompare=temp;
                                        temp=vehicleToCompare.Where(x=>(x.GearBox == announcementVehicle.GearBox));
                                        if(temp.Count() > 3) 
                                        { 
                                            vehicleToCompare=temp;
                                        }
                                    }
                                }
                          }  
                       }
                    }
                    int EveryVehiclePrice = 0;
                    int numberOfVehicles = vehicleToCompare.Count();
                    foreach(var vehicle in vehicleToCompare) 
                    {
                        EveryVehiclePrice += vehicle.PriceBrutto;
                    }
                    int AveragePrice = EveryVehiclePrice / numberOfVehicles;
                    return Json(new {AveragePrice=AveragePrice,VehiclePrice=announcementVehicle.PriceBrutto});
                }
            }
        #endregion
    }
}
