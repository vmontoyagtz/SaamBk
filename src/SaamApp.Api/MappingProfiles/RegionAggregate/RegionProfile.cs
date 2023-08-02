using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Region;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>();
            CreateMap<RegionDto, Region>();
            CreateMap<CreateRegionRequest, Region>();
            CreateMap<UpdateRegionRequest, Region>();
            CreateMap<DeleteRegionRequest, Region>();
        }
    }
}