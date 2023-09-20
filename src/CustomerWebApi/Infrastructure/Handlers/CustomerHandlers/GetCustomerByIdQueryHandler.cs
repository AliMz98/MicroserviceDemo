using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Application.Models;
using CustomerWebApi.Application.Queries;
using MediatR;

namespace CustomerWebApi.Infrastructure.Handlers.CustomerHandlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByIdAsync(request.id);
        }
    }
}
