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
    public class CompanyInvitationsRepository: Repository<CompanysInvitations>, ICompanyInvitationsRepostiory
    {
        private readonly DbAccess _db;
        public CompanyInvitationsRepository(DbAccess db):base(db)
        {
            _db = db;
        }
        public bool Exist(Expression<Func<CompanysInvitations, bool>> expression)
        {
            return _db.CompanysInvitations.Any(expression);
        }
        
    }
    
}
