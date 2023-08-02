using AutoMapper;
using SaamApp.BlazorMauiShared.Models.ProductCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategory>();
            CreateMap<CreateProductCategoryRequest, ProductCategory>();
            CreateMap<UpdateProductCategoryRequest, ProductCategory>();
            CreateMap<DeleteProductCategoryRequest, ProductCategory>();
        }
    }
}