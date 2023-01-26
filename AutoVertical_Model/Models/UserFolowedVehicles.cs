
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AutoVertical_Model.Models
{
    public class UserFolowedVehicles
    {
        [Key]
        public int id { get;set; }
        public string UserId { get; set; }
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
    }
}
