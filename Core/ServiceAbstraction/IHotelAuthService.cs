using Shared;
using Shared.Dto_s.IdentityDto_s;
using Shared.Dto_s.IdentityDto_s.HotelUser;
using Shared.Dto_s.IdentityDto_s.SecurityUser;
using Shared.Dto_s.IdentityDto_s.TouristUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IHotelAuthService
    {
        //Login
        Task<AuthResponseHotelDto> LoginHotelAsync(LoginHotelDto login);
        Task<AuthResponseHotelDto> RegisterHotelAsync(RegisterHotelDto model);

        Task<bool> ForgotPasswordHotelAsync(ForgetPasswordHotelDto model);
        Task<bool> ResetPasswordHotelAsync(ResetPasswordHotelDto resetDto);
    }
}
