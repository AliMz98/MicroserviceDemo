using ProductWebApi.Application.Models;

namespace ProductWebApi.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(Guid d);
        Task<Guid> CreateProductAsync(CreateProductDto dto);
        Task UpdateProductAsync(ProductDto dto);
        Task DeleteProductAsync(Guid id);
    }
}
