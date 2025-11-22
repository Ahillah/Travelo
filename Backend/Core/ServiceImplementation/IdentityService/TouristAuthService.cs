using DomainLayer.Models.IdentityModule;
using DomainLayer.Models.Users;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared;
using Shared.Dto_s.IdentityDto_s;
using Shared.Dto_s.IdentityDto_s.SecurityUser;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.IdentityService
{
    public class TouristAuthService : ITouristAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public TouristAuthService (UserManager<ApplicationUser>  userManager,IConfiguration configuration)
        {
           this.userManager = userManager;
            this.configuration = configuration;
        }
        public async Task<AuthResponseDto> LoginAsync(LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            bool isValid = false;

            if (user != null)
            {
                isValid = await userManager.CheckPasswordAsync(user, login.Password);
            }

            if (!isValid)
            {
                return new AuthResponseDto
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Invalid email or password." }
                };
            }

            
          

            return new AuthResponseDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                IsSuccess = true,
                Token = await CreateTokenAsync(user),
                UserType = user.UserType
            };
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterDto model)
        {
            var User = new Tourist()
            {
                Email = model.Email,
                UserName = model.Email,
                DisplayName = model.Name,

                UserType = "Tourist",


                IDNumber = model.IDNumber,
               

            };
            var Result = await userManager.CreateAsync(User, model.Password);

            if (Result.Succeeded)
            {
                return new AuthResponseDto()
                {
                    IsSuccess = true,
                    DisplayName = User.DisplayName,
                    Email = User.Email,
                    Token = await CreateTokenAsync(User),
                    UserType = User.UserType
                };


            }
            else
            {
                return new AuthResponseDto()
                {
                    IsSuccess = false,
                    Errors = Result.Errors.Select(e => e.Description).ToList()

                };
            }
        }

        public async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var claim = new List<Claim>()
            {
              new Claim (ClaimTypes.Email, user.Email!),
              new Claim(ClaimTypes.Name,user.DisplayName!),
              new Claim(ClaimTypes.NameIdentifier,user.Id!)

            };
            var Roles = await userManager.GetRolesAsync(user);
            foreach (var Role in Roles)
            {
                claim.Add(new Claim(ClaimTypes.Role, Role));
            }
            var secretKey = configuration.GetSection("JwtOptions")["SecretKey"];
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
               issuer: configuration.GetSection("JwtOptions")["Issuer"],
               audience: configuration.GetSection("JwtOptions")["Audience"],
               signingCredentials: Creds,
               expires: DateTime.Now.AddHours(1),
               claims: claim


                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

        public Task<bool> ForgotPasswordAsync(ForgetPasswordDto model)
        {
            throw new NotImplementedException();
        }



        //public async  Task<bool> ForgotPasswordAsync(ForgetPasswordDto passwordDto)
        //{
        //    var User = await userManager.FindByEmailAsync(passwordDto.Email);
        //    if (User is null)
        //        return true;
        //    else
        //    {
        //        var token = await userManager.GeneratePasswordResetTokenAsync(User);
        //        var verificationCodeBody = $"Your password reset code is: {token}. Please use this code to reset your password.";
        //        var email = new Email()
        //        {
        //            To = passwordDto.Email,
        //            Subject = "Varify Code",
        //            Body = verificationCodeBody

        //        };
        //        EmailSetting.SendEmail(email);

        //    }
        //}
    }
}
