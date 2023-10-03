using MediatR;
using OrderWebApi.Application.Commands;
using OrderWebApi.Application.Interfaces;

namespace OrderWebApi.Infrastructure.Handlers.OrderHandlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.id);
        }
    }
}
