using AutoMapper;
using ProductShop.Dto;
using ProductShop.Models;

namespace ProductShop.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
           
        }
    }
}
