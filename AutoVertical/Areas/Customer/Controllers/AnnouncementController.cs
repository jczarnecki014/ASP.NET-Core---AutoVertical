using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using AutoVertical_Utility.FileAcces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [BindProperties]
    public class AnnouncementController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public AnnouncementFiltersVM announcementFilter { get; set; }
        public Announcement announcementVM { get; set; }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAnnouncement(IFormFile[] files)
        {
            //Customize ModelState for specific vehicle
            switch (announcementVM.vehicle.VehicleType)
            {
                    case "car":
                        ModelState.Remove("vehicle.truck.NumberOfAxles");
                        ModelState.Remove("vehicle.truck.PermissibleGrossWeight");
                        ModelState.Remove("vehicle.truck.AllowPackage");
                    break;

                    case "truck":
                        ModelState.Remove("vehicle.car.NumberOfDoor");
                        ModelState.Remove("vehicle.car.NumberOfSeats");
                    break;

                    case "motorcycle":
                        ModelState.Remove("vehicle.truck.NumberOfAxles");
                        ModelState.Remove("vehicle.truck.PermissibleGrossWeight");
                        ModelState.Remove("vehicle.truck.AllowPackage");
                        ModelState.Remove("vehicle.car.NumberOfDoor");
                        ModelState.Remove("vehicle.car.NumberOfSeats");
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
                switch (announcementVM.vehicle.VehicleType)
                {
                    case "car":
                        _UnitOfWork.car.Add(announcementVM.vehicle.car);
                        _UnitOfWork.Save();
                        announcementVM.vehicle.motorcycle = null;
                        announcementVM.vehicle.truck = null;
                    break;

                    case "truck":
                        _UnitOfWork.truck.Add(announcementVM.vehicle.truck);
                        _UnitOfWork.Save();
                        announcementVM.vehicle.motorcycle = null;
                        announcementVM.vehicle.car = null;
                    break;

                    case "motorcycle":
                        _UnitOfWork.motorcycle.Add(announcementVM.vehicle.motorcycle);
                        _UnitOfWork.Save();
                        announcementVM.vehicle.truck = null;
                        announcementVM.vehicle.car = null;
                    break;
                }
                announcementVM.vehicle.MentionTime= DateTime.Now.Date;
                _UnitOfWork.vehicle.Add(announcementVM.vehicle);
                _UnitOfWork.Save();
                
                //Save user images in server
                foreach(var file in files) 
                {
                    fileAcces = new FileAcces(file,wwwRootPath);
                    string fileName = fileAcces.Create();
                    ImgGallery image = new ImgGallery()
                    {
                        Name= fileName,
                        VehicleId = announcementVM.vehicle.Id
                    };
                    _UnitOfWork.gallery.Add(image);
                }
                _UnitOfWork.Save();
                TempData["Success"] = "New announcement was added";
                return RedirectToAction("ShowAnnouncement",new {id = announcementVM.vehicle.Id});
            }
            else{
                return View(announcementVM);
            }
        }

        [HttpGet]
        public IActionResult ShowAnnouncement(int identifier)
        {
            /*Supplies in vehicle record*/
            announcementVM = new Announcement();
            announcementVM.vehicle = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id == identifier,includeSpecific:true);

            if(announcementVM.vehicle is null)
            {
                return NotFound();
            }

            /*Gets equimpents witch were checked by user*/
            var specificVehicle = new object();
            if(announcementVM.vehicle.car != null)
            {
                specificVehicle = announcementVM.vehicle.car;
            }
            else if(announcementVM.vehicle.truck != null)
            {
                specificVehicle= announcementVM.vehicle.truck;
            }
            else if(announcementVM.vehicle.motorcycle != null)
            {
                specificVehicle= announcementVM.vehicle.motorcycle;
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
            return View(announcementVM.vehicle);

        }

        [HttpPost]
        public IActionResult FilterAnnouncement(bool advanced_search_expanded)
        {
            var specificVehicle = new object();
            if(announcementFilter.vehicle == null)
            {
                return NotFound();
            }
            IEnumerable<Vehicle> vehicles = _UnitOfWork.vehicle.GetAll(u=>u.VehicleType == announcementFilter.vehicle.VehicleType,includeProperties:"car,truck,motorcycle");
            if(announcementFilter.vehicle.BodyType!= null) 
            {
                vehicles = vehicles.Where(u=>u.BodyType == announcementFilter.vehicle.BodyType);  // BodyType Filter
            }
            if(announcementFilter.vehicle.Brand!= null)
            {
                vehicles = vehicles.Where(u=>u.Brand == announcementFilter.vehicle.Brand);  //Brand Filter
            }
            if(announcementFilter.vehicle.Model!= null)
            {
                vehicles = vehicles.Where(u=>u.Model.Contains(announcementFilter.vehicle.Model));  //Model Filter
            }
            if(announcementFilter.ProductionYearFrom!= null)
            {
                vehicles = vehicles.Where(u=>u.ProductionYear >= announcementFilter.ProductionYearFrom);  //ProductionYear Filter
            }
            if(announcementFilter.ProductionYearTo!= null)
            {
                vehicles = vehicles.Where(u=>u.ProductionYear <= announcementFilter.ProductionYearTo);  //ProductionYear Filter
            }
            if(announcementFilter.vehicle.Fuel!= null)
            {
                vehicles = vehicles.Where(u=>u.Fuel == announcementFilter.vehicle.Fuel);  //Fuel Filter
            }
            if(announcementFilter.MileageFrom!= null)
            {
                vehicles = vehicles.Where(u=>u.Milage >= announcementFilter.MileageFrom);  //Mileage Filter
            }
            if(announcementFilter.MileageTo!= null)
            {
                vehicles = vehicles.Where(u=>u.Milage <= announcementFilter.MileageTo);  //Mileage Filter
            }
            if(announcementFilter.PriceFrom!= null)
            {
                vehicles = vehicles.Where(u=>u.PriceBrutto >= announcementFilter.PriceFrom);  //Price Filter
            }
            if(announcementFilter.PriceTo!= null)
            {
                vehicles = vehicles.Where(u=>u.PriceBrutto <= announcementFilter.PriceTo);  //Price Filter
            }
            if(announcementFilter.vehicle.CountryOfOrigin!= null)
            {
                vehicles = vehicles.Where(u=>u.CountryOfOrigin == announcementFilter.vehicle.CountryOfOrigin);  //Country Filter
            }
            if(announcementFilter.vehicle.Damaged == true)
            {
                vehicles = vehicles.Where(u=>u.Damaged == announcementFilter.vehicle.Damaged);  //Damaged Filter
            }
            if(announcementFilter.vehicle.NoAccident == true)
            {
                vehicles = vehicles.Where(u=>u.NoAccident == announcementFilter.vehicle.NoAccident);  //No Accident Filter
            }
            if(announcementFilter.vehicle.Imported != null)
            {
                vehicles = vehicles.Where(u=>u.Imported == announcementFilter.vehicle.Imported);  //Imported Filter
            }
            if(announcementFilter.vehicle.GearBox != null)
            {
                vehicles = vehicles.Where(u=>u.GearBox == announcementFilter.vehicle.GearBox);  //Gear Box Filter
            }
            if(announcementFilter.CubicCapacityFrom != null)
            {
                vehicles = vehicles.Where(u=>u.CubicCapacity >= announcementFilter.CubicCapacityFrom);  //Gear Box Filter
            }
            if(announcementFilter.CubicCapacityTo != null)
            {
                vehicles = vehicles.Where(u=>u.CubicCapacity <= announcementFilter.CubicCapacityTo);  //Gear Box Filter
            }
            if(announcementFilter.PowerFrom != null)
            {
                vehicles = vehicles.Where(u=>u.Power >= announcementFilter.PowerFrom);  //Gear Box Filter
            }
            if(announcementFilter.PowerTo != null)
            {
                vehicles = vehicles.Where(u=>u.Power <= announcementFilter.PowerTo);  //Gear Box Filter
            }
            if(announcementFilter.vehicle.Color!= null)
            {
                vehicles = vehicles.Where(u=>u.Color.Contains(announcementFilter.vehicle.Color));  //Model Filter
            }
            if(announcementFilter.vehicle.ColorType!= null)
            {
                vehicles = vehicles.Where(u=>u.ColorType ==  announcementFilter.vehicle.ColorType);  //Model Filter
            }
            if(announcementFilter.vehicle.car != null)
            {
                if(announcementFilter.vehicle.car.NumberOfDoor != null)
                {
                    vehicles = vehicles.Where(u=>u.car.NumberOfDoor == announcementFilter.vehicle.car.NumberOfDoor);
                }
                if(announcementFilter.vehicle.car.NumberOfSeats != null)
                {
                    vehicles = vehicles.Where(u=>u.car.NumberOfSeats == announcementFilter.vehicle.car.NumberOfSeats);
                }
                foreach(PropertyInfo prop in announcementFilter.vehicle.car.GetType().GetProperties())
                {
                    if(prop.PropertyType.FullName == "System.Boolean")
                    {
                        bool isChecked = (bool)prop.GetValue(announcementFilter.vehicle.car);
                        if(isChecked)
                        {
                            string propertyName = prop.Name;
                            vehicles = vehicles.Where(u=>u.car.GetType().GetProperty(propertyName).GetValue(u.car) is (bool)true); /// DO przypisania do jednej funckji
                        }
                    }
                }
            }
            else if(announcementFilter.vehicle.truck != null)
            {
                if(announcementFilter.vehicle.truck.NumberOfAxles != 0)
                {
                    vehicles = vehicles.Where(u=>u.truck.NumberOfAxles == announcementFilter.vehicle.truck.NumberOfAxles);
                }
                if(announcementFilter.vehicle.truck.DoubleRearWheels != null)
                {
                    vehicles = vehicles.Where(u=>u.truck.DoubleRearWheels == announcementFilter.vehicle.truck.DoubleRearWheels);
                }
                foreach(PropertyInfo prop in announcementFilter.vehicle.truck.GetType().GetProperties())
                {
                    if(prop.PropertyType.FullName == "System.Boolean")
                    {
                        bool isChecked = (bool)prop.GetValue(announcementFilter.vehicle.truck);
                        if(isChecked)
                        {
                            string propertyName = prop.Name;
                            vehicles = vehicles.Where(u=>u.truck.GetType().GetProperty(propertyName).GetValue(u.truck) is (bool)true); /// DO przypisania do jednej funckji
                        }
                    }
                }
            }
            else if (announcementFilter.vehicle.motorcycle != null)
            {
                foreach(PropertyInfo prop in announcementFilter.vehicle.motorcycle.GetType().GetProperties())
                {
                    if(prop.PropertyType.FullName == "System.Boolean")
                    {
                        bool isChecked = (bool)prop.GetValue(announcementFilter.vehicle.motorcycle);
                        if(isChecked)
                        {
                            string propertyName = prop.Name;
                            vehicles = vehicles.Where(u=>u.motorcycle.GetType().GetProperty(propertyName).GetValue(u.motorcycle) is (bool)true); /// DO przypisania do jednej funckji
                        }
                    }
                }
            }
            announcementFilter.Announcements = new List<Announcement>();
            foreach(var veh in vehicles) 
            {
                List<ImgGallery> gallery = _UnitOfWork.gallery.GetAll(u=>u.VehicleId==veh.Id).ToList();
                Announcement resoult = new Announcement(){ 
                    vehicle = veh,
                    images= gallery
                };
                announcementFilter.Announcements.Add(resoult);
            }
            ViewData["advanced_seearch_expanded"] = advanced_search_expanded;
            ViewData["VehicleType"] = announcementFilter.vehicle.VehicleType;
            return View(announcementFilter);
        }

        #region APIs
        [HttpGet]
        public IActionResult GetCountOfAnnouncement(string vehicleType, string? bodyType, string? vehicleBrand, string? vehicleModel, int? productionYearsFrom, 
                                                    int? productionYearsTo,string? fuelType,int? mileageFrom,int? mileageTo)
        {
            if(vehicleType == null)
            {
                return NotFound();
            }
            List<Vehicle> vehicles = _UnitOfWork.vehicle.GetAll(u=>u.VehicleType == vehicleType).ToList();
            if(bodyType != null)
            {
                vehicles = vehicles.Where(u=>u.BodyType == bodyType).ToList();
            }
            if(vehicleBrand != null)
            {
               vehicles = vehicles.Where(u=>u.Brand == vehicleBrand).ToList();
            }
            if(vehicleModel != null)
            {
                vehicles = vehicles.Where(u=>u.Model == vehicleModel).ToList();
            }
            if(productionYearsFrom != null)
            {
               vehicles = vehicles.Where(u=>u.ProductionYear >= productionYearsFrom).ToList();
            }
            if(productionYearsTo != null)
            {
                vehicles = vehicles.Where(u=>u.ProductionYear <= productionYearsTo).ToList();
            }
            if(fuelType != null)
            {
                vehicles = vehicles.Where(u=>u.Fuel == fuelType).ToList();
            }
            if(mileageFrom != null)
            {
                vehicles = vehicles.Where(u=>u.Milage >= mileageFrom).ToList();
            }
            if(mileageTo != null)
            {
                vehicles = vehicles.Where(u=>u.Milage <= mileageTo).ToList();
            }
            return Json(vehicles.Count());
        }

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

            [HttpGet]
        public IActionResult GetMentionedVehicle(string VehicleType,string? Brand)
        {
                IEnumerable<Vehicle>vehicles;
                if(VehicleType != null)
                { 
                    vehicles = _UnitOfWork.vehicle.GetAll(u=> u.VehicleType == VehicleType && DateTime.Compare(u.MentionTime,DateTime.Now.Date) > 0); // Compare date in order to check vehicle witch current announcement mention boost
                    if(vehicles.Count() < 12)
                    {
                        /// If numer of mentioned announcements is less than 12 recives announcements without payed mention status (12  is minimal number of announcements required to display on the home page )
                        List<Vehicle> tempBufor = vehicles.ToList();
                        vehicles = _UnitOfWork.vehicle.GetAll(u=> u.VehicleType == VehicleType && DateTime.Compare(u.MentionTime,DateTime.Now.Date) <= 0);
                        int missingAds = 12 - tempBufor.Count();
                        int i=0;
                        foreach(var veh in vehicles)
                        {
                            if(i >= missingAds)
                            {
                                break;
                            }
                            tempBufor.Add(veh);
                            i++;
                        }
                        vehicles = tempBufor;
                    }
                }
                else
                {
                    return NotFound();
                }
                if(Brand!= null) 
                { 
                    vehicles = vehicles.Where(x=>x.Brand == Brand);
                }
                
                List<object>VehiclesAndImages = new List<object>();

                    foreach(var veh in vehicles) 
                    {
                        VehiclesAndImages.Add(new {
                            vehicle = veh,
                            images = _UnitOfWork.gallery.GetAll(u=>u.VehicleId==veh.Id)
                        });;
                    }
               
                return Json(VehiclesAndImages);
        }
        #endregion
    }
}
