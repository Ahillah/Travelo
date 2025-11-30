
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.LocationDto_s
{
    public class UpdatedLocationDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is a required field.")]
        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        
       
        public bool IsFeatured { get; set; }

        
        public decimal CenterLatitude { get; set; }
        public decimal CenterLongitude { get; set; }

     
        public IFormFile? Image { get; set; }

    
        public string? ImageUrl { get; set; }
    }
}
