using ApiIntro.Service.Dtos.Accounts;
using ApiIntro.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiIntro.Apps.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto dto)
        {
            var result = await _service.Register(dto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _service.Login(dto);
            return StatusCode(result.StatusCode, result);

        }
        //[HttpPost]
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole identityRole1 = new IdentityRole { Name = "SuperAdmin" };
        //    IdentityRole identityRole2 = new IdentityRole { Name = "Admin" };
        //    IdentityRole identityRole3 = new IdentityRole { Name = "User" };

        //    await _roleManager.CreateAsync(identityRole1);

        //    await _roleManager.CreateAsync(identityRole2);

        //    await _roleManager.CreateAsync(identityRole3);

        //    return Ok();
        //}

    }
}
