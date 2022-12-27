using AutoVertical_Utility.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models.ViewModel
{
    public class AnnouncementFiltersVM
    {
        public Vehicle vehicle { get;set; }
        public List<Announcement>? Announcements { get;set; }
        [RangeUntilCurrentYearAttribute(1920)]
        public int? ProductionYearFrom { get; set; }
        [RangeUntilCurrentYearAttribute(1920)]
        public int? ProductionYearTo { get; set; }
        [Range(0,3000000)]
        public int? MileageFrom { get; set; }
        [Range(0,3000000)]
        public int? MileageTo { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public int? PowerFrom { get;set; }
        public int? PowerTo { get; set;}
        public int? CubicCapacityFrom{ get; set; }
        public int? CubicCapacityTo{ get;set; }
        public int? PermissibleGrossWeightFrom{ get;set;}
        public int? PermissibleGrossWeightTo{ get;set;}
        public int? AllowPackageFrom{ get;set;}
        public int? AllowPackageTo{ get;set;}
    }
}
