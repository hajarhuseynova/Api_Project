using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntro.Service.Dtos.Accounts
{
    public record LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
