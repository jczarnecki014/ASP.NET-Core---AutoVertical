using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class Motorcycle
    {
        /*This model contains specify properties for Motorcycle  */
       [Key]
       public int Id { get; set; }

       [Required]
       public string Drive { get; set; }

       //____________________________________________________________________________________________ Specify vehicle equipemnt

        [DefaultValue(false)]
        public bool ABS{ get;set;}

        [DefaultValue(false)]
        public bool Alarm{ get;set;}

        [DefaultValue(false)]
        public bool ImmobilizerTrunk{ get;set;}

        [DefaultValue(false)]
        public bool HeatedGrips{ get;set;}

        [DefaultValue(false)]
        public bool Radio{ get;set;}

         //_____________________________________________________________ ToStirngEquipment


        public string? MotorcycleEquipmentToString { get;set;}
    }
}
