using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Area;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<Area, AreaDto>();
            CreateMap<AreaDto, Area>();
            CreateMap<CreateAreaRequest, Area>();
            CreateMap<UpdateAreaRequest, Area>();
            CreateMap<DeleteAreaRequest, Area>();
        }
    }
}