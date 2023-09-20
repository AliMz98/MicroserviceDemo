using CustomerWebApi.Application.Models;
using MediatR;

namespace CustomerWebApi.Application.Queries
{
    public record GetCustomerByIdQuery(Guid id):IRequest<CustomerDto>;
    public record GetCustomerListQuery():IRequest<IEnumerable<CustomerDto>>;
}
