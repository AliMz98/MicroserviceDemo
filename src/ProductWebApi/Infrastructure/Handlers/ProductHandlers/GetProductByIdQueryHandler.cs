using ProductWebApi.Application.Interfaces;
using ProductWebApi.Application.Models;
using ProductWebApi.Application.Queries;
using MediatR;

namespace ProductWebApi.Infrastructure.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByIdAsync(request.id);
        }
    }
}
