using AutoMapper;
using OrderWebApi.Application.Models;
using OrderWebApi.Domain.Entities;

namespace ProductWebApi.Application
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

        }
    }
}
