using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    class Car
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

        //____________________________________________________________________________________________Specify vehicle equipemnt

        [DefaultValue(false)]
        public bool 


    }
}
