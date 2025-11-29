using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.Dto_s.LocationDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController:ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locationsDto = await locationService.GetAllLocationsAsync();
            return Ok(locationsDto);
        }
        [HttpGet("Featured")]
        public async Task<IActionResult> GetFeaturedLocations()
        {
            var locationsDto = await locationService.GetFeaturedLocationsAsync();
            return Ok(locationsDto);
        }
       
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var locationDto = await locationService.GetLocationByIdAsync(id);

            if (locationDto == null)
            {
                return NotFound(); 
            }

            return Ok(locationDto);
        }
        [HttpPost]
        [Consumes("multipart/form-data")] 
        
        public async Task<IActionResult> CreateLocation([FromForm] CreatedLocationDto locationDto)
        {
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             await locationService.CreateLocationAsync(locationDto);
            return Ok("Created");
        }


        
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
      
        public async Task<IActionResult> UpdateLocation(int id, [FromForm] UpdatedLocationDto locationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

                await locationService.UpdateLocationAsync(id, locationDto);
            return Ok(locationDto);
          
         
        }

  
        [HttpDelete("{id}")]
       
        public async Task<IActionResult> DeleteLocation(int id)
        {
            
                await locationService.DeleteLocationAsync(id);
            return Ok("Deleted");
         
        }

       
   
    }
}

