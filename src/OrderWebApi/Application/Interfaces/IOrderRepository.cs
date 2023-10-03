using OrderWebApi.Application.Models;

namespace OrderWebApi.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<string> CreateAsync(OrderDto dto);
        Task<OrderDto> GetByIDAsync(string id);
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task UpdateAsync(OrderDto dto);
        Task DeleteAsync(string id);
    }
}
