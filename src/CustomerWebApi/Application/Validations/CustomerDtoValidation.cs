using CustomerWebApi.Application.Models;
using FluentValidation;

namespace CustomerWebApi.Application.Validations
{
    public class CustomerDtoValidation : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidation()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Id)
                .NotEmpty(); 
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(50);
            RuleFor(x => x.Mobile)
                .Matches(@"^09\d{9}$")
                .MaximumLength(11);
        }
    }
}
