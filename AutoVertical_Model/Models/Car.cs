using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class Car
    {
        /*This model contains specify properties for Car  */

        [Key]
        public int Id { get; set; }

        //____________________________________________________________________________________________ Main quality

        [DefaultValue(false)]
        public bool RightHandDrive { get; set; }

        //____________________________________________________________________________________________ Technical data

        [Required]
        public string NumberOfDoor { get;set;}

        //____________________________________________________________________________________________ Body

        [Required]
        public int NumberOfSeats{ get;set; }

        //____________________________________________________________________________________________ Specify vehicle equipemnt



        //_____________________________________________________________ Audio & Multimedia
        [DefaultValue(false)]
        public bool AppleCarPlaycd { get;set;}

        [DefaultValue(false)]
        public bool BluetoothInterface { get;set;}

        [DefaultValue(false)]
        public bool LoudSpeekerSystem { get;set;}

        [DefaultValue(false)]
        public bool WirelessChargingDevices { get;set;}

        [DefaultValue(false)]
        public bool SoundSystem { get;set;}

        [DefaultValue(false)]
        public bool Touchscreen { get;set;}

        [DefaultValue(false)]
        public bool InternetAcces { get;set;}

        [DefaultValue(false)]
        public bool AndroidAuto { get;set;}

        [DefaultValue(false)]
        public bool Radio { get;set;}

        [DefaultValue(false)]
        public bool USBSocket { get;set;}

        [DefaultValue(false)]
        public bool SatelliteNavigationSystem { get;set;}

        [DefaultValue(false)]
        public bool HeadUpDisplay { get;set;}

        [DefaultValue(false)]
        public bool FunctionVoiceStering { get;set;}

        //_____________________________________________________________ Comfort

        [DefaultValue(false)]
        public bool AirConditioning { get;set;}

        [DefaultValue(false)]
        public bool HeatingSeat { get;set;}

        [DefaultValue(false)]
        public bool MassageSeats { get;set;}

        [DefaultValue(false)]
        public bool Armrests { get;set;}

        [DefaultValue(false)]
        public bool SportSteeringWheel { get;set;}

        [DefaultValue(false)]
        public bool HeatingSteeringWheel { get;set;}

        [DefaultValue(false)]
        public bool KeyLessEntry { get;set;}

        [DefaultValue(false)]
        public bool Webasto { get;set;}

        [DefaultValue(false)]
        public bool HeatingFrontWindow { get;set;}

        [DefaultValue(false)]
        public bool ElectricRearWindows { get;set;}

        [DefaultValue(false)]
        public bool OpeningRoof { get;set;}

        [DefaultValue(false)]
        public bool ElectricStearingSeats { get;set;}

        [DefaultValue(false)]
        public bool VentilatedSeats { get;set;}

        [DefaultValue(false)]
        public bool SportSeats { get;set;}

        [DefaultValue(false)]
        public bool LeatherSteeringWheel { get;set;}

        [DefaultValue(false)]
        public bool MultimediaSteeringWheel { get;set;}

        [DefaultValue(false)]
        public bool GearChangingInSteeringWheel { get;set;}

        [DefaultValue(false)]
        public bool KeylessGo { get;set;}

        [DefaultValue(false)]
        public bool RainDetector { get;set;}

        [DefaultValue(false)]
        public bool ElectricFrontWindows { get;set;}

        [DefaultValue(false)]
        public bool DigitalKey { get;set;}

        //_____________________________________________________________ Driver Support Systems

        [DefaultValue(false)]
        public bool Tempomat { get;set;}

        [DefaultValue(false)]
        public bool ParkAssistant { get;set;}

        [DefaultValue(false)]
        public bool ParkingCamera { get;set;}

        [DefaultValue(false)]
        public bool BlindSpotAssistance { get;set;}

        [DefaultValue(false)]
        public bool SpeedLimiter { get;set;}

        [DefaultValue(false)]
        public bool ESP { get;set;}

        [DefaultValue(false)]
        public bool HillHolder { get;set;}

        [DefaultValue(false)]
        public bool DuskSensor { get;set;}

        [DefaultValue(false)]
        public bool RearLedLight { get;set;}

        [DefaultValue(false)]
        public bool StartStopSystem { get;set;}

        [DefaultValue(false)]
        public bool ParkingSensors { get;set;}

        [DefaultValue(false)]
        public bool PanoramicCamera360 { get;set;}

        [DefaultValue(false)]
        public bool ElectronicMirrors { get;set;}

        [DefaultValue(false)]
        public bool LanneAssist { get;set;}

        [DefaultValue(false)]
        public bool BrakeAssist { get;set;}

        [DefaultValue(false)]
        public bool ABS { get;set;}

        [DefaultValue(false)]
        public bool ActiveRecognizedRoadSigns { get;set;}

        [DefaultValue(false)]
        public bool DailyLight { get;set;}

        [DefaultValue(false)]
        public bool LeavingHomeLight { get;set;}

        [DefaultValue(false)]
        public bool ElectricParkingBrake { get;set;}

        //_____________________________________________________________ Safety

        [DefaultValue(false)]
        public bool EmergencyBrakingAssistant { get;set;}

        [DefaultValue(false)]
        public bool AirBags { get;set;}

        [DefaultValue(false)]
        public bool Isofix { get;set;}

        [DefaultValue(false)]
        public bool ProtectionFromAccidentSystem { get;set;}

        
        //_____________________________________________________________ ToStirngEquipment


        public string? CarEquipmentToString { get;set;}



    }
}
