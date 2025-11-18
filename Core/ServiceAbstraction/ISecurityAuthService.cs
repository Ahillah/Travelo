using Shared;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface ISecurityAuthService
    {
        //Login
        Task<AuthResponseDto> LoginAsync(LoginDto login);
        Task<AuthResponseDto> RegisterAsync(RegisterDto model);
        Task<bool> ForgotPasswordAsync(string email);

    }
}
