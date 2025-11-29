using Shared.Dto_s.LocationDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetAllLocationsAsync();
        Task<IEnumerable<LocationDto>> GetFeaturedLocationsAsync();
        Task<LocationDto?> GetLocationByIdAsync(int id);
        Task CreateLocationAsync(CreatedLocationDto locationDto);
        Task UpdateLocationAsync(int id, UpdatedLocationDto locationDto);
        Task DeleteLocationAsync(int id);
    }
}
