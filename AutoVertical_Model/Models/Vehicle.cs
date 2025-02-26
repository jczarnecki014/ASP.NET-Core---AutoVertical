﻿using AutoVertical_Utility.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class Vehicle
    {
        /*This model contains common/shared properties within all types of vehicle  */


        //____________________________________________________________________________________________ Vehicle details
        [Key]
        public int Id { get; set; }

        [Required]
        public string VehicleType { get;set;}

        [Required]
        public string Imported { get; set; }

        [DefaultValue(false)]
        public bool Damaged { get; set; }

        //____________________________________________________________________________________________ Basic information

        [Required]
        public string VinNumber{ get;set;}

        [Required]
        public int Milage { get;set;}

        [Required]
        public string VehicleRegistrationNumber { get;set;}

        [Required(ErrorMessage="This value is required")]
        [Range(1,31,ErrorMessage="You should type value between 1 and 31")]
        public int RegDay{ get;set;}

        [Required]
        [Range(1,12,ErrorMessage="You should type value between 1 and 12")]
        public int RegMonth{ get;set;}

        [Required]
        [RangeUntilCurrentYearAttribute(1920)]
        public int RegYear{ get;set;}


        //____________________________________________________________________________________________ Technical data

        [Required]
        [RangeUntilCurrentYearAttribute(1920)]
        public int ProductionYear { get;set;}

        [Required]
        public string Brand{ get;set;}

        [Required]
        public string Model{ get;set;}

        [Required]
        public string Fuel{ get;set;}

        [Required]
        [Range(10,1500,ErrorMessage="You should type value between 10 and 1500")]
        public int Power{ get;set;}

        [Required]
        [Range(1,10000,ErrorMessage = "This value is unreal" )]
        public int CubicCapacity{ get;set;}

        [Required]
        public string GearBox{ get;set;}

        [Required]
        public string? Drive { get; set; }

        public int? Co2Emision{ get;set;}

        //____________________________________________________________________________________________ Body

        [Required]
        public string BodyType { get;set;}

        [Required]
        public string Color { get;set;}

        [Required]
        public string ColorType { get;set;}

        //____________________________________________________________________________________________ Vehicle description

        [Required]
        [MaxLength(40,ErrorMessage="This title is too long, please shorten it")]
        [MinLength(5,ErrorMessage="You should write more about this vehicle")]
        public string Title{ get;set;}

        [Required]
        [MaxLength(4000,ErrorMessage="Sorry, but your description exceed 4000 characters")]
        [MinLength(10,ErrorMessage="You should write more about this vehicle")]
        public string Description{ get;set;}

        //____________________________________________________________________________________________ Vehicle History
        [Required]
        public string CountryOfOrigin{ get;set;}

        //____________________________________________________________________________________________ Vehicle stans
        [DefaultValue(false)]
        public bool FirstOwner{ get;set;}

        [DefaultValue(false)]
        public bool AsoServiced{ get;set;}

        [DefaultValue(false)]
        public bool Tuning{ get;set;}

        [DefaultValue(false)]
        public bool NoAccident{ get;set;}

        [DefaultValue(false)]
        public bool RegisteredAsMonument{ get;set;}

        //____________________________________________________________________________________________ Vehicle Price

        [Required]
        [Range(1,100000000,ErrorMessage ="Alowed value is between 1 and 100 000 000 PLN")]
        public int PriceBrutto { get;set;}

        //____________________________________________________________________________________________ Purpose options

        [DefaultValue(false)]
        public bool ToNegotiate{ get;set;}

        [DefaultValue(false)]
        public bool VAT{ get;set;}

        [DefaultValue(false)]
        public bool Leasing{ get;set;}


        //____________________________________________________________________________________________ Specific vehicle


        public int? CarId { get;set;}
        [ValidateNever]
        public Car car{ get;set;}

        public int? TruckId { get;set;}
        [ValidateNever]
        public Truck truck{ get;set;}

        public int? MotorcycleId { get;set;}
        [ValidateNever]
        public Motorcycle motorcycle{ get;set;}

        //____________________________________________________________________________________________ Special states
        [Column(TypeName="date")]
        public DateTime CreateDate{ get;set;}
        [Column(TypeName="date")]
        public DateTime MentionTime{ get;set;}
        [Column(TypeName="date")]
        public DateTime ExpireDate{ get;set;}

        [ValidateNever]
        public string VehicleDirectoryPath { get;set;}

        [ValidateNever]
        public string UserId { get;set;}
        [ValidateNever]
        [ForeignKey("UserId")]
        public ApplicationUser User{ get;set;}
        public ICollection<ImgGallery>? gallery { get;set;}
    }
}
