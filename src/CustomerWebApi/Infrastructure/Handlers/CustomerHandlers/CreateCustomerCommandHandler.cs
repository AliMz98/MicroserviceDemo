using CustomerWebApi.Application.Commands;
using CustomerWebApi.Application.Interfaces;
using MediatR;

namespace CustomerWebApi.Infrastructure.Handlers.CustomerHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateCustomerAsync(request.Dto);
        }
    }
}
