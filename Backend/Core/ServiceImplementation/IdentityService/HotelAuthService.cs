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
using Shared.Dto_s.IdentityDto_s.SecurityUser;
using Shared.Dto_s.IdentityDto_s.TouristUser;
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
        public async Task<AuthResponseHotelDto> LoginHotelAsync(LoginHotelDto login)
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
        public async Task<AuthResponseHotelDto> RegisterHotelAsync(RegisterHotelDto model)
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
        public async Task<bool> ForgotPasswordHotelAsync(ForgetPasswordHotelDto passwordDto)
        {
            /* var user = await userManager.FindByEmailAsync(passwordDto.Email);
             if (user is null)
                 return false;

             // 👈 هنا الشرط المهم: لازم يكون Hotel
             var isHotel = await userManager.IsInRoleAsync(user, "Hotel");
             if (!isHotel)
                 return false;

             var identityToken = await userManager.GeneratePasswordResetTokenAsync(user);

             var random = new Random();
             string shortCode = random.Next(10000, 99999).ToString();

             var verificationCodeBody =
                 $"Your password reset code is: {shortCode}. Please use this code to reset your password.";

             user.ResetPasswordCode = shortCode;
             user.ResetPasswordToken = identityToken;
             user.ResetPasswordExpiry = DateTime.UtcNow.AddMinutes(10);

             await userManager.UpdateAsync(user);

             var email = new Email
             {
                 To = passwordDto.Email,
                 Subject = "Verify Code",
                 Body = verificationCodeBody
             };

             EmailSetting.SendEmail(email);

             return true;*/
            var user = await userManager.FindByEmailAsync(passwordDto.Email);
            if (user is null)
                return false;

            // نتأكد إنه فعلاً Hotel عن طريق UserType
            if (user.UserType != "Hotel")
                return false;

            var identityToken = await userManager.GeneratePasswordResetTokenAsync(user);

            var random = new Random();
            string shortCode = random.Next(10000, 99999).ToString();

            var verificationCodeBody =
                $"Your password reset code is: {shortCode}. Please use this code to reset your password.";

            user.ResetPasswordCode = shortCode;
            user.ResetPasswordToken = identityToken;
            user.ResetPasswordExpiry = DateTime.UtcNow.AddMinutes(10);

            await userManager.UpdateAsync(user);

            var email = new Email
            {
                To = passwordDto.Email,
                Subject = "Verify Code",
                Body = verificationCodeBody
            };

            EmailSetting.SendEmail(email);

            return true;
        }
       

      
        public async Task<bool> ResetPasswordHotelAsync(ResetPasswordHotelDto resetDto)
        {
            /* var user = await userManager.FindByEmailAsync(resetDto.Email);
             if (user is null)
                 return false;

             // 👈 برضه نتأكد إنه Hotel
             var isHotel = await userManager.IsInRoleAsync(user, "Hotel");
             if (!isHotel)
                 return false;

             if (user.ResetPasswordCode != resetDto.VerificationCode)
                 return false;

             if (user.ResetPasswordExpiry == null || user.ResetPasswordExpiry < DateTime.UtcNow)
                 return false;

             var identityToken = user.ResetPasswordToken;

             if (string.IsNullOrEmpty(identityToken))
                 return false;

             var result = await userManager.ResetPasswordAsync(user, identityToken, resetDto.NewPassword);
             if (!result.Succeeded)
                 return false;

             user.ResetPasswordCode = null;
             user.ResetPasswordToken = null;
             user.ResetPasswordExpiry = null;

             await userManager.UpdateAsync(user);

             return true;*/


            // 1) نجيب اليوزر بالإيميل
            var user = await userManager.FindByEmailAsync(resetDto.Email);
            if (user == null)
            {
                Console.WriteLine("[Reset] User not found");
                return false;
            }

            // 2) نتأكد إنه Hotel (لو عندك UserType)
            if (user.UserType != "Hotel")
            {
                Console.WriteLine("[Reset] User is not Hotel");
                return false;
            }

            // 3) الكود
            Console.WriteLine($"[Reset] Stored code: {user.ResetPasswordCode}, Sent: {resetDto.VerificationCode}");
            if (user.ResetPasswordCode != resetDto.VerificationCode)
            {
                Console.WriteLine("[Reset] Code mismatch");
                return false;
            }

            // 4) الصلاحية
            Console.WriteLine($"[Reset] Expiry: {user.ResetPasswordExpiry}, Now: {DateTime.UtcNow}");
            if (user.ResetPasswordExpiry == null || user.ResetPasswordExpiry < DateTime.UtcNow)
            {
                Console.WriteLine("[Reset] Code expired");
                return false;
            }

            // 5) التوكن
            var identityToken = user.ResetPasswordToken;
            if (string.IsNullOrEmpty(identityToken))
            {
                Console.WriteLine("[Reset] Identity token is null or empty");
                return false;
            }

            // 6) Reset الباسورد
            var resetResult = await userManager.ResetPasswordAsync(user, identityToken, resetDto.NewPassword);
            if (!resetResult.Succeeded)
            {
                Console.WriteLine("[Reset] ResetPasswordAsync failed:");
                foreach (var error in resetResult.Errors)
                {
                    Console.WriteLine($" - {error.Code}: {error.Description}");
                }
                return false;
            }

            // 7) ننضف بيانات الريسيت
            user.ResetPasswordCode = null;
            user.ResetPasswordToken = null;
            user.ResetPasswordExpiry = null;

            var updateResult = await userManager.UpdateAsync(user);

            Console.WriteLine($"[Reset] Update result: {updateResult.Succeeded}");
            return updateResult.Succeeded;

        }
     



    }
}

