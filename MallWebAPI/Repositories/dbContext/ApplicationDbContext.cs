using Microsoft.EntityFrameworkCore;
using Repositories.Mall;

namespace Repositories.dbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       
        [System.Obsolete]
        public DbQuery<DBContactUs> ContactUss { get; set; }
        [System.Obsolete]
        public DbQuery<DBCustomerMaster> CustomerMasters { get; set; }
        [System.Obsolete]
        public DbQuery<DBLogin> Logins { get; set; }
       
    }
}
