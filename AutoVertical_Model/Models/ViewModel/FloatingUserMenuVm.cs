using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models.ViewModel
{
    public class FloatingUserMenuVm
    {
        public ApplicationUser user{ get; set; }
        public Company userCompany { get;set; }
        public int userNotyficationsCount{ get;set; }
    }
}
