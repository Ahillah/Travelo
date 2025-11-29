using AutoMapper;
using DomainLayer.Models;
using Shared.Dto_s.LocationDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.MappingProfile
{
    public class LocationProfile :Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<CreatedLocationDto, Location>();
            
            CreateMap<UpdatedLocationDto, Location>()
    .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
        }
    }
}
