using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class TraveloIdentityDbContextFactory : IDesignTimeDbContextFactory<TraveloIdentityDbContext>
    {
        public TraveloIdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TraveloIdentityDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=Travel.Identity;Trusted_Connection=True;TrustServerCertificate=True;");

            return new TraveloIdentityDbContext(optionsBuilder.Options);
        }
    }
}
