using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models.ViewModel
{
    public class CompanyVM
    {
        public Company company { get; set; }
        public List<ApplicationUser> members { get; set; }
        public List<Vehicle> companyAdverts { get; set; }
        public List<Advertisement> companyAdvertisements { get; set; }
        public CompanyRoles LoggedUserRole { get; set; }
        public int? SoldVehicles{ get;set; }
    }
}
