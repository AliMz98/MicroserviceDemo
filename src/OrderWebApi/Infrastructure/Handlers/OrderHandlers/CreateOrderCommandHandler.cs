using MediatR;
using OrderWebApi.Application.Commands;
using OrderWebApi.Application.Interfaces;

namespace OrderWebApi.Infrastructure.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateAsync(request.Dto);
        }
    }
}
