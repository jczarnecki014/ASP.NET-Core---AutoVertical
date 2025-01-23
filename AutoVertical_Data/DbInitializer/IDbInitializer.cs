using AutoVertical_Data.DbInitializer.EntityInitiaizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVertical_Data.DbInitializer
{
    public interface IDbInitializer
    {
        public Task InitializeAsync(params IEntityInitializer[] modelList);
    }
}
