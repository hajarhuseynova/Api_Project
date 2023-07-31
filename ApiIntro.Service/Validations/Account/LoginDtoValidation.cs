using ApiIntro.Service.Dtos.Accounts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntro.Service.Validations.Account
{
    public class LoginDtoValidation: AbstractValidator<LoginDto>
    {

		public LoginDtoValidation()
		{
			RuleFor(x => x.Username)
				.MinimumLength(8)
				.MaximumLength(25)
				.NotEmpty().NotNull();

			RuleFor(x => x.Password)
				.NotEmpty()
				.NotNull()
				.MinimumLength(8);
		}

	}

}
