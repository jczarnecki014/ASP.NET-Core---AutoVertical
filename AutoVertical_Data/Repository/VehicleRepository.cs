using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository
{
    public class VehicleRepository:Repository<Vehicle>,IVehicleRepository
    {
        private readonly DbAccess _db;
        public VehicleRepository(DbAccess db):base(db)
        {
            _db = db;
        }
        public void Update(Vehicle entity){
            _db.Update(entity);
        }
        public Vehicle GetFirstOfDefault(Expression<Func<Vehicle, bool>> filter,bool includeSpecific = false)
        {
            IQueryable<Vehicle> query =_db.Vehicles;
            query = query.Where(filter);
            if(includeSpecific)
            {
                var vehicleType = query.Select(u=>u.VehicleType).SingleOrDefault();
                if(vehicleType != null)
                {
                    query = query.Include(vehicleType);
                }
            }
            return query.FirstOrDefault();

        }
    }
    
}
