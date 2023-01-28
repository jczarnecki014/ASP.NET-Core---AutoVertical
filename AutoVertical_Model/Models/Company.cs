using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class Company
    {
        [Key]
        public int id { get;set; }
        public string name { get;set; }
        public string description { get;set; }
        [ValidateNever]
        public string LogoSrc { get;set; }
        [Url]
        public string? WebsiteUrl { get;set;}
        public string City { get;set; }
        public string Country { get;set; }
        public string PostalCode { get;set; }
        public string StreetName{ get;set; }
        public string StreetNumber{ get;set; }
        [EmailAddress]
        public string Email { get;set; }
        [Phone]
        public string PhoneNumber{ get;set; }
        public string? Fax { get;set; }
        public int? ActiveAdverts{ get;set; }
        public int? ActiveAdvertisements { get;set; }
        public int? SoldAverts{ get;set;}

    }
}
