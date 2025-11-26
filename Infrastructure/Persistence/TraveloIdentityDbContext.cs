using DomainLayer.Models;
using DomainLayer.Models.IdentityModule;
using DomainLayer.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class TraveloIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public TraveloIdentityDbContext(DbContextOptions<TraveloIdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");

            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}