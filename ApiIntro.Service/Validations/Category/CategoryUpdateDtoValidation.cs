
using ApiIntro.Service.Dtos.Categories;
using FluentValidation;

namespace ApiIntro.Validations.Categories
{
    public class ProductUpdateDtoValidation : AbstractValidator<CategoryPostDto>
    {

        public ProductUpdateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not empty")
                .NotNull().WithMessage("Name can not null")
                .MinimumLength(3)
                .MaximumLength(30);
         

        }
    }
}