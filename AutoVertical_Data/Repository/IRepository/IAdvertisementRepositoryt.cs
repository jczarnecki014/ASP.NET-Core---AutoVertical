using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository.IRepository
{
    public interface IAdvertisementRepositoryt:IRepository<Advertisement>
    {
        public void Update(Advertisement entity){}
        public IEnumerable<Advertisement> GetAll(Expression<Func<Advertisement, bool>>? filter = null,bool Expired=false, bool ActiveInFuture = false);
    }
}
