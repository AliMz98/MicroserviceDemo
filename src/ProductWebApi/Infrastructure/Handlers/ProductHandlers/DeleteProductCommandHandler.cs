using ProductWebApi.Application.Commands;
using ProductWebApi.Application.Interfaces;
using MediatR;

namespace ProductWebApi.Infrastructure.Handlers.ProductHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteProductAsync(request.id);
        }
    }
}
