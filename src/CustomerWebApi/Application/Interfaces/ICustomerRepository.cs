using CustomerWebApi.Application.Models;

namespace CustomerWebApi.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(Guid d);
        Task<Guid> CreateCustomerAsync(CreateCustomerDto dto);
        Task UpdateCustomerAsync(CustomerDto dto);
        Task DeleteCustomerAsync(Guid id);

    }
}
