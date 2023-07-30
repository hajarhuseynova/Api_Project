
using ApiIntro.Service.Dtos.Products;
using ApiIntro.Service.Helpers;
using FluentValidation;

namespace ApiIntro.Validations.Products
{
    public class ProductPostDtoValidation : AbstractValidator<ProductPostDto>
    {

        public ProductPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not empty")
                .NotNull().WithMessage("Name can not null")
                .MinimumLength(3)
                .MaximumLength(30);
            RuleFor(x => x).Custom((x, content) =>
            {
                if (!x.File.isImage())
                {
                    content.AddFailure("File","File is not valid");
                }
                if (!x.File.isSizeOk(2))
                {
                    content.AddFailure("File", "File is not valid");
                }
            });

        }
    }
}