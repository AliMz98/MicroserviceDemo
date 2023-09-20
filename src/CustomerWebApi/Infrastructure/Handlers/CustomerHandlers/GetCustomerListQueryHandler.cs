using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Application.Models;
using CustomerWebApi.Application.Queries;
using MediatR;

namespace CustomerWebApi.Infrastructure.Handlers.CustomerHandlers
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;
        public GetCustomerListQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomersAsync();
        }
    }
}
