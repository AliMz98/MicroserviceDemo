using AutoMapper;
using ProductWebApi.Application.Models;
using ProductWebApi.Domain.Entities;

namespace ProductWebApi.Application
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

        }
    }
}
