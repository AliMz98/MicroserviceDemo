using ProductWebApi.Application.Models;
using FluentValidation;

namespace ProductWebApi.Application.Validations
{
    public class CreateProductDtoValidation : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidation()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Price)
                .NotEmpty();
        }
    }
}
