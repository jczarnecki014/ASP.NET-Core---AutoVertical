using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository.IRepository
{
    public interface IUserFollowedVehicleRepository:IRepository<UserFolowedVehicles>
    {
        public void Update(UserFolowedVehicles entity){}
    }
}
