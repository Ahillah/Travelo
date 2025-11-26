using AutoMapper;
using DomainLayer.Models;
using DomainLayer.RepositoryInterface;
using ServiceAbstraction;
using Shared.Dto_s.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation
{
    public class TripService(ITripRepository repo, IMapper mapper) : ITripService
    {
        private readonly ITripRepository _repo = repo;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<TripDto>> GetAllAsync()
        {
            var trips = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<TripDto>>(trips);
        }

        public async Task<TripDto?> GetByIdAsync(int id)
        {
            var trip = await _repo.GetByIdAsync(id);
            return trip == null ? null : _mapper.Map<TripDto>(trip);
        }

        public async Task CreateAsync(CreateTripDto dto)
        {
            var trip = _mapper.Map<Trip>(dto);
            await _repo.AddAsync(trip);
            await _repo.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, UpdateTripDto dto)
        {
            var trip = await _repo.GetByIdAsync(id);
            if (trip == null) return;

            _mapper.Map(dto, trip);
            await _repo.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var trip = await _repo.GetByIdAsync(id);
            if (trip == null) return;

            await _repo.DeleteAsync(trip);
            await _repo.SaveChangesAsync();
        }
    }
}
