using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.IdentityDto_s
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string IDNumber { get; set; } 

        [Required]
        public string AffiliatedSecurityAgency { get; set; } 

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool AgreeToTerms { get; set; } 
    }
}
