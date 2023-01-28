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
            Vehicle vehicleFromDb = dbSet.FirstOrDefault(u=>u.Id == entity.Id);
            if(vehicleFromDb != null)
            {
                vehicleFromDb.Imported = entity.Imported;
                vehicleFromDb.Damaged = entity.Damaged;
                vehicleFromDb.VinNumber = entity.VinNumber;
                vehicleFromDb.Milage = entity.Milage;
                vehicleFromDb.VehicleRegistrationNumber = entity.VehicleRegistrationNumber;
                vehicleFromDb.RegDay = entity.RegDay;
                vehicleFromDb.RegMonth = entity.RegMonth;
                vehicleFromDb.RegYear = entity.RegYear;
                vehicleFromDb.ProductionYear = entity.ProductionYear;
                vehicleFromDb.Brand = entity.Brand;
                vehicleFromDb.Model = entity.Model;
                vehicleFromDb.Fuel = entity.Fuel;
                vehicleFromDb.Power = entity.Power;
                vehicleFromDb.CubicCapacity = entity.CubicCapacity;
                vehicleFromDb.GearBox = entity.GearBox;
                vehicleFromDb.Drive = entity.Drive;
                vehicleFromDb.Co2Emision = entity.Co2Emision;
                vehicleFromDb.BodyType = entity.BodyType;
                vehicleFromDb.Color = entity.Color;
                vehicleFromDb.ColorType = entity.ColorType;
                vehicleFromDb.Title = entity.Title;
                vehicleFromDb.Description = entity.Description;
                vehicleFromDb.CountryOfOrigin = entity.CountryOfOrigin;
                vehicleFromDb.FirstOwner = entity.FirstOwner;
                vehicleFromDb.FirstOwner = entity.FirstOwner;
                vehicleFromDb.Title = entity.Title;
                vehicleFromDb.AsoServiced = entity.AsoServiced;
                vehicleFromDb.Tuning = entity.Tuning;
                vehicleFromDb.RegisteredAsMonument = entity.RegisteredAsMonument;
                vehicleFromDb.PriceBrutto = entity.PriceBrutto;
                vehicleFromDb.ToNegotiate = entity.NoAccident;
                vehicleFromDb.VAT = entity.VAT;
                vehicleFromDb.Leasing = entity.Leasing;
                vehicleFromDb.Co2Emision = entity.Co2Emision;
            }
        }
        public Vehicle GetFirstOfDefault(Expression<Func<Vehicle, bool>> filter,bool includeSpecific = false,bool Expired=false)
        {
            IQueryable<Vehicle> query =_db.Vehicles;
            
            query = query.Where(filter);

            if(Expired == false)
            {
                query = query.Where(u=>DateTime.Compare(DateTime.Now.Date,u.ExpireDate) <=0);
            }


            if(includeSpecific)
            {
                var vehicleType = query.Select(u=>u.VehicleType).SingleOrDefault();
                query = query.Include("User");
                if(vehicleType != null)
                {
                    query = query.Include(vehicleType);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<Vehicle> GetAll(Expression<Func<Vehicle, bool>>? filter = null, string? includeProperties = null,bool Expired=false)
        {
            IQueryable<Vehicle> query;
            if(filter != null)
            {
                query = dbSet.Where(filter);
            }
            else{
                query = dbSet;
            }

            if(Expired == false)
            {
                query = query.Where(u=>DateTime.Compare(DateTime.Now.Date,u.ExpireDate) <=0);
            }

            if(includeProperties != null){
                foreach(var property in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                { 
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }
    }
    
}
