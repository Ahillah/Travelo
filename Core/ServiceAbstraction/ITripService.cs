using Shared.Dto_s.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface ITripService
    {
        Task<IEnumerable<TripDto>> GetAllAsync();
        Task<TripDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateTripDto dto);
        Task UpdateAsync(int id, UpdateTripDto dto);
        Task DeleteAsync(int id);
    }
}
