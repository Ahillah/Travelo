/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Contollers.AuthControllers
{
    internal class HotelAccountController
    {

    }
}*/
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.Dto_s.IdentityDto_s;
using Shared.Dto_s.IdentityDto_s.HotelUser; // ← ده مهم علشان LoginHotelDto / RegisterHotelDto / AuthResponseHotelDto

namespace Presentation.Contollers.AuthControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelAccountController(IHotelAuthService authService) : ControllerBase
    {
        // POST: api/HotelAccount/Login
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseHotelDto>> Login(LoginHotelDto login)
        {
            var user = await authService.LoginAsync(login);

            if (!user.IsSuccess)
            {
                return BadRequest(user);
            }

            return Ok(user);
        }

        // POST: api/HotelAccount/Register
        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponseHotelDto>> Register(RegisterHotelDto register)
        {
            var user = await authService.RegisterAsync(register);

            if (!user.IsSuccess)
            {
                return BadRequest(user);
            }

            return Ok(user);
        }
    }
}

