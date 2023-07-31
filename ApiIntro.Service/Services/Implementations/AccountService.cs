using ApiIntro.Service.Dtos.Accounts;
using ApiIntro.Service.Responses;
using ApiIntro.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntro.Service.Services.Implementations
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<ApiResponse> Login(LoginDto dto)
        {
            IdentityUser? user = await _userManager.FindByNameAsync(dto.Username);

            if (user == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Username or password is not correct" };
            }

            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                return new ApiResponse { StatusCode = 404, Description = "Username or password is not correct" };
            }
            string keyStr = _configuration["Jwt:SecretKey"];
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtSecurityToken Jwttoken = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(3),
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               claims: claims,
               signingCredentials: credentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(Jwttoken);

            return new ApiResponse { StatusCode = 200, Items = new { token = token } };
        }

        public async Task<ApiResponse> Register(RegisterDto dto)
        {
            IdentityUser identityUser = new IdentityUser
            {
                UserName = dto.Username,
                Email = dto.Email,
            };

            var result = await _userManager.CreateAsync(identityUser, dto.Password);

            if (!result.Succeeded)
            {
                return new ApiResponse { StatusCode = 400, Items = result.Errors };
            }

            await _userManager.AddToRoleAsync(identityUser, "Admin");
            return new ApiResponse { StatusCode = 200 };
        }
    }
}
