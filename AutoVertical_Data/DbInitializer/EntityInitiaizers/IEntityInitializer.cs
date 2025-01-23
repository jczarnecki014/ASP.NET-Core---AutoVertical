using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.DbInitializer.EntityInitiaizers
{
    public interface IEntityInitializer
    {
        public Task PushEntityAsync(DbAccess db);
    }
}
