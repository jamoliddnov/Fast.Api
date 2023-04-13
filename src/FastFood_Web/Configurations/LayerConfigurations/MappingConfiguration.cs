using AutoMapper;
using FastFood_Web.Domain.Entities;
using FastFood_Web.Service.Dtos.CategoryEmpolyeeDto;
using FastFood_Web.Service.Dtos.CategoryProductDto;

namespace FastFood_Web.Api.Configurations.LayerConfigurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<CreateCategoryEmpolyeeDto, CategoryEmpolyee>().ReverseMap();
            CreateMap<CreateCategoryProductDto, CategoryProduct>().ReverseMap();
        }
    }
}
