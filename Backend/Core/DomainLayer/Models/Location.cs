using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Location
    {
        public int Id { get; set; }

       
        public string? Name { get; set; } 
         public string? Country { get; set; } 
        public string Description { get; set; } 
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; } = false;

        public decimal CenterLatitude { get; set; }
        public decimal CenterLongitude { get; set; }

    }
}
