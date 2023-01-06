using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository
{
    public class AdvertisementRepository:Repository<Advertisement>,IAdvertisementRepositoryt
    {
        private readonly DbAccess _db;
        public AdvertisementRepository(DbAccess db):base(db)
        {
            _db = db;
        }
        public void Update(AdvertStats entity){
            _db.Update(entity);
        }
    }
    
}
