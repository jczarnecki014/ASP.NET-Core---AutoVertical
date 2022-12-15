using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    
}
