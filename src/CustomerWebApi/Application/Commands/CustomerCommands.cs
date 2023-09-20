using CustomerWebApi.Application.Models;
using MediatR;

namespace CustomerWebApi.Application.Commands
{
    public record CreateCustomerCommand(CreateCustomerDto Dto):IRequest<Guid>;
    public record UpdateCustomerCommand(CustomerDto Dto) : IRequest;
    public record DeleteCustomerCommand(Guid id) : IRequest;
}
