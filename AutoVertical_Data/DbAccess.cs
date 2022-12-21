
using AutoVertical_Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoVertical_Data
{
    public class DbAccess:IdentityDbContext
    {
        public DbAccess(DbContextOptions<DbAccess> options):base(options)
        {
        }
        public DbSet<Vehicle> Vehicles{ get; set; }
        public DbSet<Car> Cars{ get; set;}
        public DbSet<Truck> Trucks{ get; set; }
        public  DbSet<Motorcycle> Motorcycles{ get; set;}
        public  DbSet<ImgGallery> ImgGallery{ get; set; }

    }
}
