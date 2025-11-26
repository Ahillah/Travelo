using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.IdentityDto_s.HotelUser
{
    public class AuthResponseHotelDto
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string DisplayName { get; set; }

        public string Email { get; set; }
        public string UserType { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
