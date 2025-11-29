using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.LocationDto_s
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; }
    }
}
