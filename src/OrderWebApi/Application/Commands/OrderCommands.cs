using OrderWebApi.Application.Models;
using MediatR;

namespace OrderWebApi.Application.Commands
{
    public record CreateOrderCommand(OrderDto Dto):IRequest<string>;
    public record UpdateOrderCommand(OrderDto Dto) : IRequest;
    public record DeleteOrderCommand(string id) : IRequest;
}
