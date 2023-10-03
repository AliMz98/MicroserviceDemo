using MediatR;
using OrderWebApi.Application.Commands;
using OrderWebApi.Application.Interfaces;

namespace OrderWebApi.Infrastructure.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(request.Dto);
        }
    }
}
