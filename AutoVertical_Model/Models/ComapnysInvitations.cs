using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models
{
    public class CompanysInvitations
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public ApplicationUser User{ get; set; }
    }
}
