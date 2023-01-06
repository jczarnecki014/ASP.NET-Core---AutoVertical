using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models.ViewModel
{
    public class UserPanelVM
    {
        public string Tab{ get; set; } 
        public object? OptionalArg{ get;set;}
        public ApplicationUser User {get;set;}
    }
}
