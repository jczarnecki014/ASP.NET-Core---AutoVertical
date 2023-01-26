using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using Microsoft.EntityFrameworkCore;
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
            applicationUser = new ApplicationUserRepository(db);
            messages = new MessageRepository(db);
            conversation = new ConversationRepository(db);
            advertStats= new AdvertStatsRepository(db);
            advertisement = new AdvertisementRepository(db);
            notyfications = new NotyficationRepository(db);
            userFollowedVehicle = new UserFollowedVehicleRepository(db);
            
        }
        public IVehicleRepository vehicle { get; private set;}

        public ICarRepository car { get; private set;}

        public ITruckRepository truck { get; private set;}

        public IMotorcycleRepository motorcycle { get; private set;}
        public IGalleryRepository gallery { get;private set;}

        public IApplicationUserRepository applicationUser {get; private set;}
        public IMessageRepository messages {get; private set;}
        public IConversationRepository conversation {get; private set;}

        public IAdvertStatsRepository advertStats {get; private set;}
        public IAdvertisementRepositoryt advertisement{ get; private set;}
        public INotyficationRepository notyfications{ get; private set;}

        public IUserFollowedVehicleRepository userFollowedVehicle { get;private set;}

        public void Save() 
        {
            _db.SaveChanges();
            /*_db.ChangeTracker.DetectChanges(); // sprawdzić czy można usunąć*/
        }
    }
}
