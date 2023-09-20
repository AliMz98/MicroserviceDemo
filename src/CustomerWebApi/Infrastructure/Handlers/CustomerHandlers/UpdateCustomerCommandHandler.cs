using CustomerWebApi.Application.Commands;
using CustomerWebApi.Application.Interfaces;
using MediatR;

namespace CustomerWebApi.Infrastructure.Handlers.CustomerHandlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.UpdateCustomerAsync(request.Dto);
        }
    }
}
