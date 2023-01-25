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
    public class AdvertisementRepository:Repository<Advertisement>,IAdvertisementRepositoryt
    {
        private readonly DbAccess _db;
        public AdvertisementRepository(DbAccess db):base(db)
        {
            _db = db;
        }
        public void Update(Advertisement entity)
        {
            Advertisement advertisement = dbSet.FirstOrDefault(u=>u.Id == entity.Id);
            if(advertisement != null)
            { 
                if(entity.ImageSrc !=null)
                {
                    advertisement.ImageSrc = entity.ImageSrc;
                }
                advertisement.Url = entity.Url;
            }
            _db.Update(advertisement);
        }

        public IEnumerable<Advertisement> GetAll(Expression<Func<Advertisement, bool>>? filter = null,bool Expired=false, bool ActiveInFuture = false)
        {
            IQueryable<Advertisement> query;
            if(filter != null)
            {
                query = dbSet.Where(filter);
            }
            else{
                query = dbSet;
            }

            if(Expired == false)
            {
                query = query.Where(u=>DateTime.Compare(DateTime.Now.Date,u.ActiveTo) <=0);
            }
            if(ActiveInFuture == false)
            {
                query = query.Where(u=>DateTime.Compare(DateTime.Now.Date,u.ActiveFrom) >=0);
            }
            return query.ToList();
        }
    }
    
}
