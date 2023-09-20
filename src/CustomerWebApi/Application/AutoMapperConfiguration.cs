using AutoMapper;
using CustomerWebApi.Application.Models;
using CustomerWebApi.Domain.Entities;

namespace CustomerWebApi.Application
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
