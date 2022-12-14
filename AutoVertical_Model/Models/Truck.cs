using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class Truck
    {
        /*This model contains specify properties for TRUCK  */
        [Key]
        public int Id { get; set; }

        //____________________________________________________________________________________________ Main quality

        [DefaultValue(false)]
        public bool NonStandarVehicle { get; set; }

        [DefaultValue(false)]
        public bool DoubleRearWheels { get; set; }

        //____________________________________________________________________________________________ Technical data

        [Required]
        [Range(2,3, ErrorMessage = "Please type a correct value")]
        public int NumberOfAxles { get; set; }

        //____________________________________________________________________________________________ Cargo

        [Required]
        [Range(5000,40000, ErrorMessage = "Please type a correct value")]
        public int AllowPackage { get; set; }

        [Required]
        [Range(5000,50000, ErrorMessage = "Please type a correct value")]
        public int PermissibleGrossWeight { get; set; }

        //____________________________________________________________________________________________ Specify vehicle equipemnt

        [DefaultValue(false)]
        public bool Drive4x4{ get;set;}

        [DefaultValue(false)]
        public bool ABS{ get;set;}
        
        [DefaultValue(false)]
        public bool Alarm{ get;set;}

        [DefaultValue(false)]
        public bool CbRadio{ get;set;}

        [DefaultValue(false)]
        public bool CD{ get;set;}

        [DefaultValue(false)]
        public bool CentralLock{ get;set;}

        [DefaultValue(false)]
        public bool ParkingSensor{ get;set;}

        [DefaultValue(false)]
        public bool DVD{ get;set;}

        [DefaultValue(false)]
        public bool ElectrisGlasses{ get;set;}

        [DefaultValue(false)]
        public bool ESP{ get;set;}

        [DefaultValue(false)]
        public bool Immobilizer{ get;set;}

        [DefaultValue(false)]
        public bool Intarder{ get;set;}

        [DefaultValue(false)]
        public bool SleepingCabing{ get;set;}

        [DefaultValue(false)]
        public bool AutomaticAirCondition{ get;set;}

        [DefaultValue(false)]
        public bool OnBoardComputer{ get;set;}

        [DefaultValue(false)]
        public bool Kitchen{ get;set;}

        [DefaultValue(false)]
        public bool Fridge{ get;set;}

        [DefaultValue(false)]
        public bool MiniBar{ get;set;}

        [DefaultValue(false)]
        public bool GPSNAV{ get;set;}

        [DefaultValue(false)]
        public bool Webasto{ get;set;}

        [DefaultValue(false)]
        public bool AirBags{ get;set;}

        [DefaultValue(false)]
        public bool FactoryRadio{ get;set;}

        [DefaultValue(false)]
        public bool NotFactoryRadio{ get;set;}

        [DefaultValue(false)]
        public bool AdjustableSuspension{ get;set;}

        [DefaultValue(false)]
        public bool Retarder{ get;set;}

        [DefaultValue(false)]
        public bool Tachography{ get;set;}

        [DefaultValue(false)]
        public bool CruiseControl{ get;set;}

        [DefaultValue(false)]
        public bool Toilet{ get;set;}

        [DefaultValue(false)]
        public bool TVTuner{ get;set;}

        [DefaultValue(false)]
        public bool MultifunctionSteeringWheel{ get;set;}

        //_____________________________________________________________ ToStirngEquipment

        public string? TruckEquipmentToString { get;set;}
    }
}
