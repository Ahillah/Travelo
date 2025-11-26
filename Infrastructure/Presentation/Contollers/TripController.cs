using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.Dto_s.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _service;

        public TripController(ITripService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTripDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTripDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
