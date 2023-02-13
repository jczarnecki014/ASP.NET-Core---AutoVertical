using AutoVertical_Data.Repository.IRepository;
using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository
{
    public class CompanyRepository:Repository<Company>,ICompanyRepostiory
    {
        private readonly DbAccess _db;
        public CompanyRepository(DbAccess db):base(db)
        {
            _db = db;
        }
        public void Update(Company entity){
                Company currentCompany = _db.company.FirstOrDefault(u=>u.id == entity.id);
                currentCompany.name = entity.name;
                currentCompany.Email = entity.Email;
                currentCompany.PhoneNumber = entity.PhoneNumber;
                currentCompany.Fax = entity.Fax;
                currentCompany.WebsiteUrl = entity.WebsiteUrl;
                currentCompany.Country = entity.Country;
                currentCompany.City = entity.City;
                currentCompany.PostalCode = entity.PostalCode;
                currentCompany.StreetName = entity.StreetName;
                currentCompany.StreetNumber = entity.StreetNumber;
                if(entity.LogoSrc != null)
                {
                    currentCompany.LogoSrc = entity.LogoSrc;
                }
                _db.Update(currentCompany);
        }

        public bool Exist(Expression<Func<Company, bool>> expression)
        {
            return _db.company.Any(expression);
        }

    }
    
}
