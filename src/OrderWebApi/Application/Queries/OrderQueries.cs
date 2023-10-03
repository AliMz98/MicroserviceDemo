using OrderWebApi.Application.Models;
using MediatR;

namespace OrderWebApi.Application.Queries
{
    public record GetOrderByIdQuery(string Id):IRequest<OrderDto>;
    public record GetOrderListQuery():IRequest<IEnumerable<OrderDto>>;

}
 