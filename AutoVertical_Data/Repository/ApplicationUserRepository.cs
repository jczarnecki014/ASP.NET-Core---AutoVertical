using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository
{
    public class ApplicationUserRepository:Repository<ApplicationUser>,IApplicationUserRepository
    {
        private readonly DbAccess _db;
        public ApplicationUserRepository(DbAccess db):base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser entity){
            ApplicationUser user = dbSet.FirstOrDefault(u=>u.Id == entity.Id);
            user.UserName = entity.UserName;
            user.Name = entity.Name;
            user.Surname = entity.Surname;
            user.PhoneNumber = entity.PhoneNumber;
            user.City = entity.City;
            user.Street = entity.Street;
            user.PostCode = entity.PostCode;
            if(user.AvatarSrc!= null)
            {
                user.AvatarSrc= entity.AvatarSrc;
            }
        }
    }
    
}
