using ProductWebApi.Application.Models;
using MediatR;

namespace ProductWebApi.Application.Commands
{
    public record CreateProductCommand(CreateProductDto Dto):IRequest<Guid>;
    public record UpdateProductCommand(ProductDto Dto) : IRequest;
    public record DeleteProductCommand(Guid id) : IRequest;
}
