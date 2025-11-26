using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<IEnumerable<Location>> GetFeaturedLocationsAsync();
        Task<Location?> GetByIdAsync(int id);
        Task AddAsync(Location location);    
        void Update(Location location);
        void Delete(Location location);
        Task SaveChangesAsync();

    }
}
