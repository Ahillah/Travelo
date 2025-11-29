using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.LocationDto_s
{
    public class CreatedLocationDto
    {
        [Required(ErrorMessage = "Location Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

      

        [Required(ErrorMessage = "Location Image is required.")]
        public IFormFile?  Image{ get; set; }

  
        public bool IsFeatured { get; set; } = false;

       
        public decimal CenterLatitude { get; set; }
        public decimal CenterLongitude { get; set; }
    }
}
