using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class AdvertStats
    {
        public int? id { get; set; }
        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
        public DateTime date { get;set; }
        [DefaultValue(0)]
        public int? AdvertViewsCount { get; set; }
        [DefaultValue(0)]
        public int? PhoneNumberDisplays { get; set; }

    }
}
