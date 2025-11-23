using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.IdentityDto_s.HotelUser
{
    public class RegisterHotelDto
    {
        // Hotel Information
     

        [Required(ErrorMessage = "Hotel Name is required")]
        [MaxLength(100)]
        public string HotelName { get; set; }

        [Required(ErrorMessage = "Full Hotel Address is required")]
        [MaxLength(200)]
        public string FullHotelAddress { get; set; }

        [Required(ErrorMessage = "Responsible Person's Name is required")]
        [MaxLength(100)]
        public string ResponsiblePersonName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Administrative Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string AdministrativeEmail { get; set; }
        [Required]
        public int HotelId { get; set; }

        // ---------------------------
        // Login / Account Info
        // ---------------------------

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        // ---------------------------
        // Terms & Conditions
        // ---------------------------

        [Required(ErrorMessage = "You must agree to the terms and conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
      public bool AcceptTerms { get; set; }
    }
}
