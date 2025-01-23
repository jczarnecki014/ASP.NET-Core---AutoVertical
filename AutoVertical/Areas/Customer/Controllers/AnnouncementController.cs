using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using AutoVertical_Model.Models.ViewModel;
using AutoVertical_Utility;
using AutoVertical_Utility.FileAcces;
using AutoVertical_Utility.UserDirectories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.FileProviders;
using Stripe.Checkout;
using System;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

namespace AutoVertical_web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [BindProperties]
    public class AnnouncementController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public AnnouncementFiltersAdvertisementsVM announcementFilter { get; set; }
        public Announcement announcementVM { get; set; }
        public AnnouncementController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment) 
        {
            _UnitOfWork = unitOfWork;
            _WebHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult EditAnnnouncement(int vehicleId)
        {
            if(vehicleId == null)
            {
                return NotFound();
            }
            Announcement announcement = new Announcement();
            announcement.vehicle = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id == vehicleId,includeSpecific:true);
            announcement.images = _UnitOfWork.gallery.GetAll(u=>u.VehicleId == vehicleId).ToList();
            ViewData["Announcement_Images_Max_Count"] = Options.Announcement_Images_Max_Count;
            return View(announcement);
        }

        [HttpPost]
        public IActionResult EditAnnnouncement(IFormFile[]? files )
        {
            if(files.Length > 0)
            {
              int ExistingFilesCount =  _UnitOfWork.gallery.GetAll(u=>u.VehicleId == announcementVM.vehicle.Id).Count();
              int FreeImagesPlaces = Options.Announcement_Images_Max_Count - ExistingFilesCount; // Control from adding more images than 12

              IFileAcces fileAcces;
              string wwwRootPath = _WebHostEnvironment.WebRootPath;
              for(int i=0; i<FreeImagesPlaces && i<files.Length; i++)
              {
                    fileAcces = new FileAcces(files[i],wwwRootPath,announcementVM.vehicle.VehicleDirectoryPath);
                    if(!fileAcces.FileState.isValid)
                    {
                        TempData["Error"] = "File is incorrect";
                        break;
                    }
                    else
                    {
                        string fileName = fileAcces.Create();
                        ImgGallery image = new ImgGallery()
                        {
                            Name = fileName,
                            VehicleId = announcementVM.vehicle.Id
                        };
                        _UnitOfWork.gallery.Add(image);
                        TempData["Success"] = "Photo was updated";
                    }
              }
              _UnitOfWork.Save();
              return RedirectToAction("EditAnnnouncement",new{vehicleId=announcementVM.vehicle.Id});
            }

            if(ModelState.IsValid)
            {
                _UnitOfWork.vehicle.Update(announcementVM.vehicle);
                switch (announcementVM.vehicle.VehicleType)
                {
                    case "car":
                        _UnitOfWork.car.Update(announcementVM.vehicle.car);
                    break;
                    case "truck":
                        _UnitOfWork.truck.Update(announcementVM.vehicle.truck);
                    break;
                    case "motorcycle":
                        _UnitOfWork.motorcycle.Update(announcementVM.vehicle.motorcycle);
                    break;
                }

                _UnitOfWork.Save();
            }

            return RedirectToAction("EditAnnnouncement",new{vehicleId=announcementVM.vehicle.Id});
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateAnnouncement()
        {
                return View();
        }

        [HttpPost]
        [Authorize]
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

            //Check images validation before db connection
            IFileAcces fileAcces;
            string wwwRootPath = _WebHostEnvironment.WebRootPath;

            foreach(var file in files) 
            {
                fileAcces = new FileAcces(file);

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
                announcementVM.vehicle.CreateDate = DateTime.Now.Date;
                announcementVM.vehicle.ExpireDate = DateTime.Now.Date.AddDays(Options.Advert_Default_Active_Day); //default value to change
                var claimUser = (ClaimsIdentity)User.Identity;
                var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);
                announcementVM.vehicle.UserId = claim.Value;

                string userId = claim.Value;
                IUserDirectory userDirectory = new UserDirectory(userId,wwwRootPath);

                string advertDirectoryPath = userDirectory.CreateAdvertDirectory();
                announcementVM.vehicle.VehicleDirectoryPath= advertDirectoryPath;
                _UnitOfWork.vehicle.Add(announcementVM.vehicle);
                _UnitOfWork.Save();
                

                //Save user images in server
                foreach(var file in files) 
                {
                    fileAcces = new FileAcces(file,wwwRootPath,advertDirectoryPath);
                    string fileName = fileAcces.Create();
                    ImgGallery image = new ImgGallery()
                    {
                        Name= fileName,
                        VehicleId = announcementVM.vehicle.Id
                    };
                    _UnitOfWork.gallery.Add(image);
                }
                _UnitOfWork.Save();
                return RedirectToAction("ShowAnnouncement",new {identifier = announcementVM.vehicle.Id});
            }
            else{
                return View();
            }
        }


        [HttpPost]
        public IActionResult announcementImage(int imageId)
        {
            ImgGallery Image = _UnitOfWork.gallery.GetFirstOfDefault(u=>u.Id == imageId);
            IEnumerable<ImgGallery> EveryVehicleImg = _UnitOfWork.gallery.GetAll(u=>u.VehicleId == Image.VehicleId);
            if(EveryVehicleImg.Count() <=3)
            {
                return Json(new {
                    resoult = "Error !",
                    Message = "Your advert have to consist of minimum 3 images ! Plese add more images before remove this position"
                });
            }
            else
            {
                string wwwRoot = _WebHostEnvironment.WebRootPath;
                IFileAcces.Delete(wwwRoot+Image.Name);
                _UnitOfWork.gallery.Remove(Image);
                _UnitOfWork.Save();
                return Json(new {
                    resoult = "Success !",
                    Message = "This image was remove correctly"
                });
            }
        }


        [HttpGet]
        public IActionResult ShowAnnouncement(int identifier)
        {
            /*Supplies in vehicle record*/
            AnnouncementFiltersAdvertisementsVM announcement = new AnnouncementFiltersAdvertisementsVM();
            announcement.vehicle = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id == identifier,includeSpecific:true,Expired:true);

            if(announcement.vehicle is null)
            {
                return NotFound();
            }

            /*Gets equimpents witch were checked by user*/
            var specificVehicle = new object();
            if(announcement.vehicle.car != null)
            {
                specificVehicle = announcement.vehicle.car;
            }
            else if(announcement.vehicle.truck != null)
            {
                specificVehicle= announcement.vehicle.truck;
            }
            else if(announcement.vehicle.motorcycle != null)
            {
                specificVehicle= announcement.vehicle.motorcycle;
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
            ViewBag.UserAdvertsConunt = _UnitOfWork.vehicle.GetAll(u=>u.UserId == announcement.vehicle.UserId).Count();

            ///
            /// <summary>Load similar vehicles</summary>
            ///

            IEnumerable<Vehicle> recommendedVehicles = _UnitOfWork.vehicle.GetAll(u=>u.Id != announcement.vehicle.Id && u.VehicleType == announcement.vehicle.VehicleType &&
                                                        (
                                                            u.Brand == announcement.vehicle.Brand || 
                                                            u.BodyType == announcement.vehicle.BodyType ||
                                                            u.GearBox == announcement.vehicle.GearBox
                                                        )); //Vehicles different as currently main displayed but having similar features

            List<Announcement> recommendedAnnouncements = new List<Announcement>();
            int maxNumbersRecommendedVehicleToDisplay = 4;
            int iterator = 0;
            foreach(Vehicle vehicle in recommendedVehicles)
            {
                if(iterator < maxNumbersRecommendedVehicleToDisplay)
                {
                    recommendedAnnouncements.Add
                    (
                        new Announcement
                        {
                            vehicle = vehicle,
                            images = _UnitOfWork.gallery.GetAll(u=>u.VehicleId== vehicle.Id).ToList()
                        }
                    );
                    iterator++;
                }
                else
                {
                    break;
                }
            }

            announcement.Announcements = recommendedAnnouncements;



            ///
            /// <summary>Increase advert views stats </summary>
            ///

            DateTime Date = DateTime.Now.Date;

            AdvertStats vehicleStats = _UnitOfWork.advertStats.GetFirstOfDefault(u=>u.VehicleId == identifier && Date == u.date.Date);
            if(vehicleStats == null) 
            {
                vehicleStats = new AdvertStats()
                {
                    VehicleId = identifier,
                    date = Date,
                    AdvertViewsCount = 0,
                    PhoneNumberDisplays = 0
                };
            }

            vehicleStats.AdvertViewsCount += 1;

            _UnitOfWork.advertStats.Update(vehicleStats);
            _UnitOfWork.Save();
            
            ///<summary>
            /// If user appear own announcement, don't show (announcement follow option)
            /// </summary>

            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);

            if(claim != null)
            {
                string LoggedUser = claim.Value;

                ViewBag.CurrentUser = LoggedUser;
            }

            return View(announcement);

        }
        [HttpGet,ActionName("FilterAnnouncement")]
        public IActionResult GetUserAnnouncements(string userId)
        {
            return FilterAnnouncement(advanced_search_expanded:false,userId:userId);
        }
        [HttpPost]
        public IActionResult FilterAnnouncement(bool advanced_search_expanded,string? userId = null)
        {
            var specificVehicle = new object();
            IEnumerable<Vehicle> vehicles;
            if(userId != null)
            {
                announcementFilter = new AnnouncementFiltersAdvertisementsVM();
                announcementFilter.vehicle = new Vehicle();
            }

            if(announcementFilter.vehicle == null)
            {
                return NotFound();
            }

            if(userId !=null)
            {
                vehicles = _UnitOfWork.vehicle.GetAll(u=>u.UserId == userId,includeProperties:"car,truck,motorcycle,User");
            }
            else
            {
                vehicles = _UnitOfWork.vehicle.GetAll(u=>u.VehicleType == announcementFilter.vehicle.VehicleType,includeProperties:"car,truck,motorcycle,User");
            }

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
                    company = _UnitOfWork.company.GetFirstOfDefault(u=>u.id == veh.User.CompanyId),
                    images= gallery
                };
                announcementFilter.Announcements.Add(resoult);
            }
            ViewData["advanced_seearch_expanded"] = advanced_search_expanded;
            ViewData["VehicleType"] = announcementFilter.vehicle.VehicleType;
            return View(announcementFilter);
        }

        [HttpPost]
        public IActionResult DeleteAnnouncement(int vehicleId,bool sold = false)
        {
            //Remove vehicle
            Vehicle vehToRemove = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id ==vehicleId,includeSpecific:true,Expired:true);
            _UnitOfWork.vehicle.Remove(vehToRemove);

            //Remove images
            IEnumerable<ImgGallery> VehicleGalery = _UnitOfWork.gallery.GetAll(u=>u.VehicleId==vehicleId);
            string wwwRoot = _WebHostEnvironment.WebRootPath;
            string? FileDirectory = null;
            foreach(ImgGallery img in VehicleGalery)
            {
                FileDirectory = IFileAcces.Delete(wwwRoot+img.Name);
            }
            IUserDirectory.DeleteDirectory(FileDirectory);
            _UnitOfWork.gallery.RemoveRange(VehicleGalery);

            //Remove specific vehicle
            switch (vehToRemove.VehicleType)
            {
                case "car":
                    _UnitOfWork.car.Remove(vehToRemove.car);
                break;
                case "truck":
                    _UnitOfWork.truck.Remove(vehToRemove.truck);
                break;
                case "motorcycle":
                    _UnitOfWork.motorcycle.Remove(vehToRemove.motorcycle);
                break;
            }

            // If vehicle sold increment number of sold vehicles
            if(sold == true)
            {
                vehToRemove.User.SoldVehicles += 1;
                _UnitOfWork.applicationUser.Update(vehToRemove.User);
            }

            _UnitOfWork.Save();
            return RedirectToAction("Index","UserProfile",new{
            tab="AdvertsTab"}
            );
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
                    Vehicle announcementVehicle = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id == id,Expired:true);
                    IEnumerable<AutoVertical_Model.Models.Vehicle> vehicleToCompare = _UnitOfWork.vehicle.GetAll(u=>u.Brand == announcementVehicle.Brand,Expired:true);;
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
                    vehicles = _UnitOfWork.vehicle.GetAll(u=> u.VehicleType == VehicleType && DateTime.Compare(u.MentionTime,DateTime.Now.Date) >= 0); // Compare date in order to check vehicle witch current announcement mention boost
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

        [HttpGet]
        public IActionResult GetAnnouncement(int VehicleId)
        {
            if(VehicleId<0) 
            {
                return NotFound();
            }
            Vehicle vehicle = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id == VehicleId,Expired:true/*,includeSpecific:true*/);
            List<ImgGallery> vehicleGallery = _UnitOfWork.gallery.GetAll(u=>u.VehicleId == vehicle.Id).ToList();

            Announcement announcement = new Announcement
            {
                vehicle = vehicle,
                images = vehicleGallery
            };
            string state = (DateTime.Compare(DateTime.Now.Date,vehicle.ExpireDate)<=0) ? "active":"expired";
            return Json(new {
                announcement = announcement,
                state = state
            });
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAdvertStats(bool? UserAdverts, int? VehicleId, string period)
        {
            var claimUser = (ClaimsIdentity)User.Identity;
            var claim = claimUser.FindFirst(ClaimTypes.NameIdentifier);

            string userId = claim.Value;

            List<AdvertStats> advertStats = new List<AdvertStats>();
            if(VehicleId != null)
            {
                 Vehicle vehicle = _UnitOfWork.vehicle.GetFirstOfDefault(u=>u.Id == VehicleId,Expired:true );
                 if(vehicle.UserId == userId)
                 {
                     advertStats = _UnitOfWork.advertStats.GetAll(u=>u.VehicleId == VehicleId).ToList();
                 }
                 else
                 {
                    return NotFound();
                 }
            }
            else if(UserAdverts == true)
            {
                List<Vehicle>UserVehilcles = _UnitOfWork.vehicle.GetAll(u=>u.UserId == userId).ToList();
                foreach(Vehicle veh in UserVehilcles)
                {
                    IEnumerable<AdvertStats>UserVehiclesAdvertsStats = _UnitOfWork.advertStats.GetAll(u=>u.VehicleId == veh.Id);
                    advertStats.AddRange(UserVehiclesAdvertsStats);
                }

            }
            switch (period)
            {
                case "week":
                    //Get current week date
                    DateTime baseDate = DateTime.Now.Date;
                    var thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek+1);
                    var thisWeekEnd = thisWeekStart.AddDays(7);
                    advertStats = advertStats.Where(u=>u.date >= thisWeekStart && u.date <= thisWeekEnd).ToList();
                    /*advertStats = _UnitOfWork.advertStats.GetAll(u=>u.VehicleId == VehicleId && u.date >= thisWeekStart && u.date <= thisWeekEnd);*/

                break;
                case "month":
                    int thisMonth = DateTime.Now.Month;
                    advertStats = advertStats.Where(u=>thisMonth == u.date.Month).ToList();
                    /*advertStats = _UnitOfWork.advertStats.GetAll(u=>u.VehicleId == VehicleId && thisMonth == u.date.Month);*/
                break;
                case "year":
                    int thisYear = DateTime.Now.Year;
                    advertStats = advertStats.Where(u=>thisYear == u.date.Year).ToList();
                    /*advertStats = _UnitOfWork.advertStats.GetAll(u=>u.VehicleId == VehicleId && thisYear == u.date.Year);*/
                    advertStats = advertStats.OrderBy(u=>u.date.Month).ToList();
                    List<AdvertStats>CountedValueFromEveryMonth = new List<AdvertStats>();
                    int activeMonth = 0;
                    int? monthlyViewCount = 0;
                    int? monthlyPhoneNumberDisplays = 0;
                    foreach(var advert in advertStats)
                    {
                        if(activeMonth == 0)
                        {
                            activeMonth = advert.date.Month;
                        }
                        else if(activeMonth != advert.date.Month)
                        {
                            CountedValueFromEveryMonth.Add(new AdvertStats
                            { 
                                VehicleId = VehicleId,
                                date = DateTime.Parse($"""{activeMonth}/{thisYear}"""),
                                AdvertViewsCount = monthlyViewCount
                            });
                            monthlyViewCount = 0;
                            monthlyPhoneNumberDisplays = 0;
                            activeMonth = advert.date.Month;
                        }
                        monthlyViewCount += advert.AdvertViewsCount;  
                        monthlyPhoneNumberDisplays += advert.PhoneNumberDisplays;
                    }
                    if(activeMonth != 0)
                    {
                        CountedValueFromEveryMonth.Add(new AdvertStats
                        { 
                            VehicleId = VehicleId,
                            date = DateTime.Parse($"""{activeMonth}/{thisYear}"""),
                            AdvertViewsCount = monthlyViewCount,
                            PhoneNumberDisplays = monthlyPhoneNumberDisplays
                        });
                    }
                    advertStats = CountedValueFromEveryMonth;
                break;
            }


            return Json(advertStats);

        }

        [HttpPost]
        public IActionResult IncreasePhoneDisplaysNumber(int identifier)
        {
            DateTime Date = DateTime.Now.Date;

            AdvertStats vehicleStats = _UnitOfWork.advertStats.GetFirstOfDefault(u=>u.VehicleId == identifier && Date == u.date.Date);

            if(vehicleStats == null) 
            {
                vehicleStats = new AdvertStats()
                {
                    VehicleId = identifier,
                    date = Date,
                    AdvertViewsCount = 0,
                    PhoneNumberDisplays = 0
                };
            }

            vehicleStats.PhoneNumberDisplays += 1;

            _UnitOfWork.advertStats.Update(vehicleStats);
            _UnitOfWork.Save();

            return Json("SUCCES");
        }
        #endregion
    }
}
