using ProductWebApi.Application.Models;
using FluentValidation;

namespace ProductWebApi.Application.Validations
{
    public class ProductDtoValidation : AbstractValidator<ProductDto>
    {
        public ProductDtoValidation()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Id)
                .NotEmpty(); 
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Price)
                .NotEmpty();
        }
    }
}
