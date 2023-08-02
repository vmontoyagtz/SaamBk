using AutoMapper;
using SaamApp.BlazorMauiShared.Models.BusinessUnitCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BusinessUnitCategoryProfile : Profile
    {
        public BusinessUnitCategoryProfile()
        {
            CreateMap<BusinessUnitCategory, BusinessUnitCategoryDto>();
            CreateMap<BusinessUnitCategoryDto, BusinessUnitCategory>();
            CreateMap<CreateBusinessUnitCategoryRequest, BusinessUnitCategory>();
            CreateMap<UpdateBusinessUnitCategoryRequest, BusinessUnitCategory>();
            CreateMap<DeleteBusinessUnitCategoryRequest, BusinessUnitCategory>();
        }
    }
}