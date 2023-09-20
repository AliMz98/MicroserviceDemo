using ProductWebApi.Application.Interfaces;
using ProductWebApi.Application.Models;
using ProductWebApi.Application.Queries;
using MediatR;

namespace ProductWebApi.Infrastructure.Handlers.ProductHandlers
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _repository;
        public GetProductListQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductsAsync();
        }
    }
}
