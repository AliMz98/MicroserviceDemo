using ProductWebApi.Application.Commands;
using ProductWebApi.Application.Interfaces;
using MediatR;

namespace ProductWebApi.Infrastructure.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateProductAsync(request.Dto);
        }
    }
}
