//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ServiceImplementation.IdentityService
//{
//  internal class HotelAuthService
//  {
//   }
//}
using DomainLayer.Models.IdentityModule;
using DomainLayer.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared;
using Shared.Dto_s.IdentityDto_s;          // AuthResponseDto, ForgetPasswordDto لو مشتركين
using Shared.Dto_s.IdentityDto_s.HotelUser; // LoginHotelDto, HotelRegisterDto, ForgetPasswordHotelDto (عدّلي حسب فولدراتك)
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.IdentityService
{
    public class HotelAuthService : IHotelAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public HotelAuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        // ============================
        //      Login  (Hotel User)
        // ============================
        public async Task<AuthResponseHotelDto> LoginAsync(LoginHotelDto login)
        {
            // هتدوري بالـ Email
            var user = await userManager.FindByEmailAsync(login.Email);

            bool isValid = false;

            if (user != null && user.UserType == "Hotel") // نتأكد إنه Hotel User
            {
                isValid = await userManager.CheckPasswordAsync(user, login.Password);
            }

            if (!isValid)
            {
                return new AuthResponseHotelDto
                {
                    IsSuccess = false,
                    Errors = new List<string> { "Invalid email or password." }
                };
            }

            return new AuthResponseHotelDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                IsSuccess = true,
                Token = await CreateTokenAsync(user),
                UserType = user.UserType
            };
        }

        // ============================
        //      Register  (Hotel User)
        // ============================
        public async Task<AuthResponseHotelDto> RegisterhotelAsync(RegisterHotelDto model)
        {
            // HotelUser : ApplicationUser
            var user = new Hotel()
            {
               
                Email = model.AdministrativeEmail,
                UserName = model.AdministrativeEmail,
                DisplayName = model.ResponsiblePersonName,

                // نوع المستخدم
                UserType = "Hotel",

                HotelId=model.HotelId
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return new AuthResponseHotelDto()
                {
                    IsSuccess = true,
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = await CreateTokenAsync(user),
                    UserType = user.UserType
                };
            }
            else
            {
                return new AuthResponseHotelDto()
                {
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }
        }

        // ============================
        //      JWT Token (نفس اللي فوق)
        // ============================
        public async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.DisplayName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id!),
                new Claim("UserType", user.UserType ?? "Hotel")
            };

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secretKey = configuration.GetSection("JwtOptions")["SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration.GetSection("JwtOptions")["Issuer"],
                audience: configuration.GetSection("JwtOptions")["Audience"],
                signingCredentials: creds,
                expires: DateTime.Now.AddHours(1),
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ============================
        //  Forgot Password (Hotel)
        // ============================
        public Task<bool> ForgotPasswordHotelAsync(ForgetPasswordHotelDto model)
        {
            // نفس فكرة ForgotPasswordAsync للـ Tourist
            throw new NotImplementedException();
        }

        public Task<AuthResponseHotelDto> RegisterAsync(RegisterHotelDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ForgotlPasswordAsync(ForgetPasswordHotelDto model)
        {
            throw new NotImplementedException();
        }
    }
}

