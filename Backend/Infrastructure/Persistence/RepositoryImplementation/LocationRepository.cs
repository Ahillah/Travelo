using DomainLayer.Models;
using DomainLayer.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementation
{
    public class LocationRepository : ILocationRepository
    {
        private readonly TraveloIdentityDbContext dbContext;

        public LocationRepository(TraveloIdentityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await dbContext.Locations.ToListAsync();
        }



       
        public async Task<Location?> GetByIdAsync(int id)
        {
            return await dbContext.Locations.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Location>> GetFeaturedLocationsAsync()
        {
            return await dbContext.Set<Location>().Where(l=>l.IsFeatured== true).ToListAsync();
        }
        public void Update(Location location)
        {
           dbContext.Set<Location>().Update(location);
        }
        public async Task SaveChangesAsync()
        {
           await dbContext.SaveChangesAsync();
        }

      

        public void Delete(Location location)
        {
           dbContext.Locations.Remove(location);
        }

        public async Task AddAsync(Location location)
        {
           await  dbContext.Locations.AddAsync(location);
        }
    }
}
