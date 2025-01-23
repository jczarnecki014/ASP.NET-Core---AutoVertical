using AutoVertical_Model.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoVertical_Data.DbInitializer.EntityInitiaizers
{
    public class CarInitializer : IEntityInitializer
    {


        public CarInitializer() 
        {
            
        }

        public async Task PushEntityAsync(DbAccess db)
        {
            /*var vehicle = db.Vehicles.Include("car").Include("gallery");
            var jsonString = JsonSerializer.Serialize(vehicle);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "DefaultImages", "Announcement");
            File.WriteAllText($"{path}/carVehicle.json", jsonString);
*/




        /*try
        {
            var carPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "DefaultImages", "Announcement", "carVehicle.json");
            var galleryPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "DefaultImages", "Announcement", "gallery.json");
            using FileStream carsStream = new FileStream(carPath, FileMode.Open, FileAccess.Read);
            using FileStream galleryStream = new FileStream(galleryPath, FileMode.Open, FileAccess.Read);

            var vehicle = JsonSerializer.Deserialize<List<Vehicle>>(carsStream);
            var gallery = JsonSerializer.Deserialize<List<ImgGallery>>(galleryStream);
            db.Vehicles.AddRange(vehicle);
            db.ImgGallery.AddRange(gallery);
            await db.SaveChangesAsync();
        }
        catch
        {
            throw;
        }*/
        }


    }
}
