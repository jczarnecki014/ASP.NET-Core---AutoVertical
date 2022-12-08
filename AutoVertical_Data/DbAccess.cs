
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoVertical_Data
{
    public class DbAccess:IdentityDbContext
    {
        public DbAccess(DbContextOptions<DbAccess> options):base(options)
        {
        }

    }
}
