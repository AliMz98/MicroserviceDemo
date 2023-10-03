using MediatR;
using OrderWebApi.Application.Interfaces;
using OrderWebApi.Application.Models;
using OrderWebApi.Application.Queries;

namespace OrderWebApi.Infrastructure.Handlers.OrderHandlers
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _repository;

        public GetOrderListQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
