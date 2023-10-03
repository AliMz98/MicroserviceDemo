using MediatR;
using OrderWebApi.Application.Interfaces;
using OrderWebApi.Application.Models;
using OrderWebApi.Application.Queries;

namespace OrderWebApi.Infrastructure.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIDAsync(request.Id);
        }
    }
}
