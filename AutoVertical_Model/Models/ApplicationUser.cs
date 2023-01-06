using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name{ get;set; }
        [MaxLength(50)]
        [Required]
        public string Surname{ get;set; }
        [MaxLength(50)]
        [Required]
        public string Country{ get;set; }
        [MaxLength(50)]
        [Required]
        public string City{ get;set; }
        [RegularExpression("""\d{2}-\d{3}""")]
        [Required]
        public string PostCode{ get;set; }
        [Required]
        [MaxLength(50)]
        public string Street { get;set; }
        [Required]
        [MaxLength(7)]
        public string StreetNumber{ get;set; }
        public string? AvatarSrc{ get;set;}
        [MaxLength(500)]
        public string? Description { get;set; }
        [DefaultValue(false)]
        public bool Verificated{ get;set; }
        [DefaultValue(false)]
        public bool? Blocked{ get;set; }  
        [Column(TypeName="date")]
        public DateTime RegistrationDate{ get;set;}
        
        [DefaultValue(1)]
        public int? SoldVehicles { get;set; }
    }
}
