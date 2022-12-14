
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
        DbSet<Vehicle> Vehicles{ get; set; }
        DbSet<Car> Cars{ get; set;}
        DbSet<Truck> Trucks{ get; set; }
        DbSet<Motorcycle> Motorcycles{ get; set;}

    }
}
