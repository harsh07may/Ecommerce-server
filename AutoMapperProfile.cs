using AutoMapper;
using Ecommerce_server.DTOs;

namespace Ecommerce_server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
