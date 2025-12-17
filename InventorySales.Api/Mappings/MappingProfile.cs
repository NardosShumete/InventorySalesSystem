using AutoMapper;
using InventorySales.Api.DTOs;
using InventorySales.Data.Entities;

namespace InventorySales.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateProductDto, Product>();

            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.SalesDetails))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User != null ? src.User.Username : "Unknown"));
            
            CreateMap<SalesDetail, SalesDetailDto>()
                 .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
