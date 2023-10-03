using AutoMapper;
using FluentValidation;
using MongoDB.Driver;
using OrderWebApi.Application.Exceptions;
using OrderWebApi.Application.Interfaces;
using OrderWebApi.Application.Models;
using OrderWebApi.Domain.Entities;

namespace ProductWebApi.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        private readonly IValidator<OrderDto> _validator;
        private readonly IMongoDatabaseService _mongoDatabaseService;
        private readonly IMongoCollection<Order> _orders;

        public OrderRepository(IMapper mapper, IValidator<OrderDto> validator, IMongoDatabaseService mongoDatabaseService)
        {
            _mapper = mapper;
            _validator = validator;
            _mongoDatabaseService = mongoDatabaseService;
            var database = _mongoDatabaseService.GetDatabase();
            _orders = database.GetCollection<Order>(nameof(Order));
        }

        public async Task<string> CreateAsync(OrderDto dto)
        {
            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }
            var order = _mapper.Map<Order>(dto);
            order.OrderedOn = DateTime.Now;
            order.Id = string.Empty;
            await _orders.InsertOneAsync(order);
            return order.Id;
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
            var result = await _orders.DeleteOneAsync(filter);
            if (result.DeletedCount == 0)
                throw new NotFoundExcetion(nameof(Order), id);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var filter = Builders<Order>.Filter.Empty;
            var orders = await _orders.Find(filter).ToListAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetByIDAsync(string id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
            var order = await _orders.Find(filter).FirstOrDefaultAsync();
            if(order is null)
            {
                throw new NotFoundExcetion(nameof(Order), id);
            }
            return _mapper.Map<OrderDto>(order);           

        }

        public async Task UpdateAsync(OrderDto dto)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.Id, dto.Id);
            var orderAtDb = await _orders.Find(filter).FirstOrDefaultAsync();
            if (orderAtDb is null)
            {
                throw new NotFoundExcetion(nameof(Order), dto.Id);
            }
            var order = _mapper.Map<Order>(dto);
            order.OrderedOn = orderAtDb.OrderedOn;
            var result = await _orders.ReplaceOneAsync(filter, order);
            if(result.ModifiedCount == 0)
            {
                throw new CustomException("آپدیت با خطا  مواجه گشته");
            }

        }
    }
}
