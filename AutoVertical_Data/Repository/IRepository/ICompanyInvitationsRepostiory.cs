using AutoVertical_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.Repository.IRepository
{
    public interface ICompanyInvitationsRepostiory:IRepository<CompanysInvitations>
    {
        public bool Exist(Expression<Func<CompanysInvitations, bool>> expression);
    }
}
