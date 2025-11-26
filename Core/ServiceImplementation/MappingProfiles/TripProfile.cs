using AutoMapper;
using DomainLayer.Models;
using Shared.Dto_s.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceImplementation.MappingProfiles
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trip, TripDto>().ReverseMap();
            CreateMap<CreateTripDto, Trip>();
            CreateMap<UpdateTripDto, Trip>();
        }
    }
}
