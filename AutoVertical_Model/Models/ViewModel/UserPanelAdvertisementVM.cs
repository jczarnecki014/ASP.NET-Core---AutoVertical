using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Model.Models.ViewModel
{
    public class UserPanelAdvertisementVM
    {
        public IEnumerable<Advertisement> AdvertisementToShow { get;set; }
        public Advertisement AdvertisementToUpdate { get;set; }
    }
}
