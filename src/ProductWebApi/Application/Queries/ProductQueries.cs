using ProductWebApi.Application.Models;
using MediatR;

namespace ProductWebApi.Application.Queries
{
    public record GetProductByIdQuery(Guid id):IRequest<ProductDto>;
    public record GetProductListQuery():IRequest<IEnumerable<ProductDto>>;

}
