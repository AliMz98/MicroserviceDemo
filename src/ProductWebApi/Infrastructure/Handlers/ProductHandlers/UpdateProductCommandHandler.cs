using ProductWebApi.Application.Commands;
using ProductWebApi.Application.Interfaces;
using MediatR;

namespace ProductWebApi.Infrastructure.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.UpdateProductAsync(request.Dto);
        }
    }
}
