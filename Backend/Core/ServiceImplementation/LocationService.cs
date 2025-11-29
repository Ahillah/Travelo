using AutoMapper;
using DomainLayer.Models;
using DomainLayer.RepositoryInterface;
using ServiceAbstraction;
using Shared.Dto_s.LocationDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository repository;
        private readonly IAttachmentService attachmentService;

        public LocationService(ILocationRepository repository, IMapper mapper, IAttachmentService attachmentService)
        {
            this.repository = repository;
            Mapper = mapper;
            this.attachmentService = attachmentService;
        }

        public IMapper Mapper { get; }

        public async Task CreateLocationAsync(CreatedLocationDto locationDto)
        {
            if (locationDto == null)
                return;
            var location = Mapper.Map<Location>(locationDto);
            if (locationDto.Image != null)
            {
                location.ImageUrl = attachmentService.Upload(locationDto.Image, "images");

            }
                    await repository.AddAsync(location);
                    await repository.SaveChangesAsync();

                
            }
        

        public async Task DeleteLocationAsync(int id)
        {
          var Location=await  repository.GetByIdAsync(id);
            if (Location == null)
                return;
            if (!string.IsNullOrEmpty(Location.ImageUrl))
            {
                attachmentService.Delete(Location.ImageUrl); 
            }
            repository.Delete(Location);
          await  repository.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
        {
            var Locations = await repository.GetAllAsync();
            var LocationsDto = Mapper.Map<IEnumerable<LocationDto>>(Locations);
            return LocationsDto;
        }

        public async  Task<IEnumerable<LocationDto>> GetFeaturedLocationsAsync()
        {
            var Locations = await repository.GetFeaturedLocationsAsync();
            var LocationsDto = Mapper.Map<IEnumerable<LocationDto>>(Locations);
            return LocationsDto;

        }

        public async Task<LocationDto?> GetLocationByIdAsync(int id)
        {
           var Location= await repository.GetByIdAsync(id);
            var LocationDto = Mapper.Map<LocationDto>(Location);
            return LocationDto;
        }

        public async Task UpdateLocationAsync(int id, UpdatedLocationDto locationDto)
        {
            var Location = await repository.GetByIdAsync(id);
            if (Location == null)
                throw new KeyNotFoundException($"Location with ID {id} not found.");
            if(locationDto.Image != null)
            {
                if (!string.IsNullOrEmpty(Location.ImageUrl))
                {
                    attachmentService.Delete(Location.ImageUrl);
                }
                string newImageUrl = attachmentService.Upload(locationDto.Image, "images");
                Location.ImageUrl = newImageUrl;
            }
          
            Mapper.Map(locationDto, Location);
            repository.Update(Location);
           await  repository.SaveChangesAsync();

        }
    }
}
