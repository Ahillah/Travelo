using DomainLayer.Models.IdentityModule;
using DomainLayer.Models.Users;

using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using Shared;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation
{
    public class SecurityAuthService : ISecurityAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;

        
        public SecurityAuthService (UserManager<ApplicationUser>  userManager)
        {
           this.userManager = userManager;
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
                Token = CreateTokenAsync(user),
                UserType = user.UserType
            };
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterDto model)
        {
            var User = new SecurityUser()
            {
                Email = model.Email,
                UserName = model.Email,
                DisplayName = model.Name,

                UserType = "Security",


                IDNumber = model.IDNumber,
                AffiliatedSecurityAgency = model.AffiliatedSecurityAgency

            };
            var Result = await userManager.CreateAsync(User, model.Password);

            if (Result.Succeeded)
            {
                return new AuthResponseDto()
                {
                    IsSuccess = true,
                    DisplayName = User.DisplayName,
                    Email = User.Email,
                    Token = CreateTokenAsync(User),
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

        private static string CreateTokenAsync(ApplicationUser user)
        {
            return "";
        }

        public Task<bool> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

       

      
    }
}
