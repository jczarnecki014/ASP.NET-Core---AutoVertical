using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository
{
    public class TruckRepository:Repository<Truck>,ITruckRepository
    {
        private readonly DbAccess _db;
        public TruckRepository(DbAccess db):base(db)
        {
            _db = db;
        }
        public void Update(Truck entity){
            _db.Update(entity);
        }
    }
    
}
