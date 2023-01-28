using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository.IRepository
{
    public interface ICompanyUserRepostiory:IRepository<CompanyUser>
    {
        public void Update(CompanyUser entity){}
    }
}
