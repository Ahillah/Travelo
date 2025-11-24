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
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.Dto_s.IdentityDto_s;
using Shared.Dto_s.IdentityDto_s.HotelUser; // ← ده مهم علشان LoginHotelDto / RegisterHotelDto / AuthResponseHotelDto
using Shared.Dto_s.IdentityDto_s.TouristUser;
using System.Threading.Tasks;

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
            var user = await authService.LoginHotelAsync(login);

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
            var user = await authService.RegisterHotelAsync(register);

            if (!user.IsSuccess)
            {
                return BadRequest(user);
            }

            return Ok(user);
        }
        // ✔ Forget Password for Hotel
        [HttpPost("ForgetPassword")]
        public async Task<ActionResult> ForgotPassword(ForgetPasswordHotelDto passwordDto)
        {
            bool success = await authService.ForgotPasswordHotelAsync(passwordDto);

            if (success)
            {
                return Ok(new { Message = "Hotel verification code sent to email." })
                 ;
            }

            return NotFound(new { Message = "Hotel with this email was not found." });
        }
        // ✔ Reset Password for Hotel
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordHotelDto dto)
        {
            var result = await authService.ResetPasswordHotelAsync(dto);

            if (!result)
                return BadRequest("Invalid verification code or code expired.");

            return Ok("Hotel password reset successfully.");
        }
    }
}

