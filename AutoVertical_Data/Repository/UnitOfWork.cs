using AutoVertical_Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DbAccess _db;
        public UnitOfWork(DbAccess db)
        {
            _db = db;
            vehicle = new VehicleRepository(db);
            car = new CarRepository(db);
            truck = new TruckRepository(db);
            motorcycle = new MotorcycleRepository(db);
            gallery = new GalleryRepository(db);
        }
        public IVehicleRepository vehicle { get; private set;}

        public ICarRepository car { get; private set;}

        public ITruckRepository truck { get; private set;}

        public IMotorcycleRepository motorcycle { get; private set;}
        public IGalleryRepository gallery { get;private set;}

        public void Save() 
        {
            _db.SaveChanges();
        }
    }
}
