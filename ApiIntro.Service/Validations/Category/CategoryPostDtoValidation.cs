
using ApiIntro.Service.Dtos.Categories;
using FluentValidation;

namespace ApiIntro.Validations.Categories
{
    public class ProductPostDtoValidation : AbstractValidator<CategoryPostDto>
    {

        public ProductPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not empty")
                .NotNull().WithMessage("Name can not null")
                .MinimumLength(3)
                .MaximumLength(30);
          

        }
    }
}