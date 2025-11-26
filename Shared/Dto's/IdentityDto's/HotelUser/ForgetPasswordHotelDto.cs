using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.IdentityDto_s.HotelUser
{
    public class ForgetPasswordHotelDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
  

        // جاي من الزرار اللي بيضغط عليه المستخدم
      //  public string UserType { get; set; }  // Tourist / Employee / Security / Hotel
    }
}
