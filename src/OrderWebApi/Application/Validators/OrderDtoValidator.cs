using FluentValidation;
using OrderWebApi.Application.Models;

namespace OrderWebApi.Application.Validators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator() 
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(d => d.CustomerId)
                .NotEmpty();
            RuleFor(d => d.Details)
                .NotEmpty();
            RuleForEach(d => d.Details)
                .SetValidator(new OrderDetailValidator());
        }

    }
    public class OrderDetailValidator : AbstractValidator<OrderDetailDto>
    {
        public OrderDetailValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(d => d.ProductID)
                .NotEmpty();
            RuleFor(d => d.Quantity)
                .NotEmpty();
           
        }

    }
}
