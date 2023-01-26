using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository
{
    public class NotyficationRepository:Repository<Notyfications>,INotyficationRepository
    {
        private readonly DbAccess _db;
        public NotyficationRepository(DbAccess db):base(db)
        {
            _db = db;
        }
        public void Update(Notyfications entity){
            _db.Update(entity);
        }
    }
    
}
