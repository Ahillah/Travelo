using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.IdentityDto_s.HotelUser
{
    public class ResetPasswordHotelDto
    {
        public string Email { get; set; }
        public string VerificationCode { get; set; }
        public string NewPassword { get; set; }
    }
}
