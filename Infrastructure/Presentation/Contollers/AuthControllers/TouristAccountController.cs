using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.Dto_s.IdentityDto_s;
using Shared.Dto_s.IdentityDto_s.SecurityUser;
using Shared.Dto_s.IdentityDto_s.TouristUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Contollers.AuthControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TouristAccountController(ITouristAuthService authService):ControllerBase
    {
        //Login
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto login)
        { 
          var User= await authService.LoginAsync(login);
            if (!User.IsSuccess)
            {
                
                return BadRequest(User);
            }
            return Ok(User);
        }
        //Register
        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto register)
        {
            var User = await authService.RegisterAsync(register);
            if (!User.IsSuccess)
            {

                return BadRequest(User);
            }
            return Ok(User);
        }
        [HttpPost("ForgetPassword")]
        public async Task<ActionResult> ForgotPassword( ForgetPasswordDto passwordDto)
        {
         
            bool success = await authService.ForgotPasswordAsync(passwordDto);

            if (success)
            {
                return Ok(new { Message = "Verification code has been sent to your email." });
            }

            
            return NotFound(new { Message = "User with this email was not found." });
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            var result = await authService.ResetPasswordAsync(dto);

            if (!result)
                return BadRequest("Invalid code or token expired.");

            return Ok("Password reset successfully.");
        }

    }
}
