using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository.IRepository
{
    public interface IVehicleRepository:IRepository<Vehicle>
    {
        public Vehicle GetFirstOfDefault(Expression<Func<Vehicle, bool>> filter,bool includeSpecific = false);
        public void Update(Vehicle entity){}
    }
}
