using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class CompanyUser
    {
        [Key] public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }  
        public int CompanyId { get;set;}
        public string UserRole{ get; set; }
    }
}
