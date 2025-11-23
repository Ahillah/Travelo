using Shared;
using Shared.Dto_s.IdentityDto_s;
using Shared.Dto_s.IdentityDto_s.SecurityUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shared.Dto_s.IdentityDto_s.HotelUser;

namespace ServiceAbstraction
{
    public interface IHotelAuthService
    {
        //Login
        Task<AuthResponseHotelDto> LoginAsync(LoginHotelDto login);
        Task<AuthResponseHotelDto> RegisterAsync(RegisterHotelDto model);

        Task<bool> ForgotlPasswordAsync(ForgetPasswordHotelDto model);
    }
}
