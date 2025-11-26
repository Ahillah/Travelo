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
    public class TripRepository(TraveloIdentityDbContext context) : ITripRepository
    {
        private readonly TraveloIdentityDbContext _context = context;

        public async Task<IEnumerable<Trip>> GetAllAsync()
            => await _context.Trips.ToListAsync();

        public async Task<Trip?> GetByIdAsync(int id)
            => await _context.Trips.FindAsync(id);
        public async Task AddAsync(Trip trip)
            => await _context.Trips.AddAsync(trip);

        public async Task UpdateAsync(Trip trip)
            => _context.Trips.Update(trip);

        public async Task DeleteAsync(Trip trip)
            => _context.Trips.Remove(trip);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
