using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetAllAsync();
        Task<Trip?> GetByIdAsync(int id);
        Task AddAsync(Trip trip);
        Task UpdateAsync(Trip trip);
        Task DeleteAsync(Trip trip);
        Task SaveChangesAsync();
    }
}
