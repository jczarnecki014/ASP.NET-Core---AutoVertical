using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository.IRepository
{
    public interface ICompanyRepostiory:IRepository<Company>
    {
        public void Update(Company entity){}
    }
}
