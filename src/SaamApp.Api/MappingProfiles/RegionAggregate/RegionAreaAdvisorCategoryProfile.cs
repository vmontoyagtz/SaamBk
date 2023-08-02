using AutoMapper;
using SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class RegionAreaAdvisorCategoryProfile : Profile
    {
        public RegionAreaAdvisorCategoryProfile()
        {
            CreateMap<RegionAreaAdvisorCategory, RegionAreaAdvisorCategoryDto>();
            CreateMap<RegionAreaAdvisorCategoryDto, RegionAreaAdvisorCategory>();
            CreateMap<CreateRegionAreaAdvisorCategoryRequest, RegionAreaAdvisorCategory>();
            CreateMap<UpdateRegionAreaAdvisorCategoryRequest, RegionAreaAdvisorCategory>();
            CreateMap<DeleteRegionAreaAdvisorCategoryRequest, RegionAreaAdvisorCategory>();
        }
    }
}