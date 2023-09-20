using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Application.Exceptions;
using ProductWebApi.Application.Interfaces;
using ProductWebApi.Application.Models;
using ProductWebApi.Domain.Entities;
using ProductWebApi.Infrastructure.Persistence;

namespace ProductWebApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductDto> _productValidation;
        private readonly IValidator<CreateProductDto> _createProductValidation;

        public ProductRepository(AppDbContext dbContext, IMapper mapper, IValidator<ProductDto> productValidation, IValidator<CreateProductDto> createProductValidation)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productValidation = productValidation;
            _createProductValidation = createProductValidation;
        }

        public async Task<Guid> CreateProductAsync(CreateProductDto dto)
        {
            var validationResult = _createProductValidation.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var product = _mapper.Map<Product>(dto);
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var Product = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (Product == null)
            {
                throw new NotFoundExcetion(nameof(Product), id);
            }

            _dbContext.Products.Remove(Product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var Product = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (Product == null)
            {
                throw new NotFoundExcetion(nameof(Product), id);
            }

            return _mapper.Map<ProductDto>(Product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var Products = await _dbContext.Products.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(Products);
        }

        public async Task UpdateProductAsync(ProductDto dto)
        {
            var validationResult = _productValidation.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }
            var productAtDb = await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == dto.Id);
            if (productAtDb == null)
            {
                throw new NotFoundExcetion(nameof(Product), dto.Id);
            }
            var product = _mapper.Map<Product>(dto);
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
