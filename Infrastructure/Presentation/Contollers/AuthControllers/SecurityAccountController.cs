using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.Dto_s.IdentityDto_s;

namespace Presentation.Contollers.AuthControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityAccountController(ISecurityAuthService authService):ControllerBase
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
    }
}
