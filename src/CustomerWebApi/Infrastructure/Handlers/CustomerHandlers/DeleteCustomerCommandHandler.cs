using CustomerWebApi.Application.Commands;
using CustomerWebApi.Application.Interfaces;
using MediatR;

namespace CustomerWebApi.Infrastructure.Handlers.CustomerHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteCustomerAsync(request.id);
        }
    }
}
