using ApiIntro.Service.Dtos.Accounts;
using ApiIntro.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntro.Service.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<ApiResponse> Register(RegisterDto dto);
        public Task<ApiResponse> Login(LoginDto dto);
    }
}
