using AutoMapper;
using CustomerWebApi.Application.Exceptions;
using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Application.Models;
using CustomerWebApi.Application.Validations;
using CustomerWebApi.Domain.Entities;
using CustomerWebApi.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CustomerWebApi.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerDto> _customerValidation;
        private readonly IValidator<CreateCustomerDto> _createCustomerValidation;

        public CustomerRepository(AppDbContext dbContext, IMapper mapper, IValidator<CustomerDto> customerValidation, IValidator<CreateCustomerDto> createCustomerValidation)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _customerValidation = customerValidation;
            _createCustomerValidation = createCustomerValidation;
        }

        public async Task<Guid> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var validationResult = _createCustomerValidation.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var customer = _mapper.Map<Customer>(dto);
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer.Id;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new NotFoundExcetion(nameof(Customer), id);
            }

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new NotFoundExcetion(nameof(Customer), id);
            }

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            var customers = await _dbContext.Customers.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task UpdateCustomerAsync(CustomerDto dto)
        {
            var validationResult = _customerValidation.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }
            var customerAtDb = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == dto.Id);
            if (customerAtDb == null)
            {
                throw new NotFoundExcetion(nameof(Customer), dto.Id);
            }
            var customer = _mapper.Map<Customer>(dto);
            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
