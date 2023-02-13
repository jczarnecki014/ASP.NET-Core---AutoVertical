using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models.ViewModel
{
    public class CompanyVM
    {
        public List<ApplicationUser> members { get; set; }
        public List<Vehicle> companyAdverts { get; set; }
        public List<Advertisement> companyAdvertisements { get; set; }
        public ApplicationUser CurrentUser{ get;set; }
        public List<CompanysInvitations> CompanysInvitations { get;set; }
        public int? SoldVehicles{ get;set; }
    }
}
