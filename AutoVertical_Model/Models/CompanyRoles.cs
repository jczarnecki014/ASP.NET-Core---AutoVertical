using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class CompanyRoles
    {
        [Key]
        public string UserId{ get; set; }
        public string CompanyRole{ get; set; }
    }
}
