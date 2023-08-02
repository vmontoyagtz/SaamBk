using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Advisor;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorProfile : Profile
    {
        public AdvisorProfile()
        {
            CreateMap<Advisor, AdvisorDto>();
            CreateMap<AdvisorDto, Advisor>();
            CreateMap<CreateAdvisorRequest, Advisor>();
            CreateMap<UpdateAdvisorRequest, Advisor>();
            CreateMap<DeleteAdvisorRequest, Advisor>();
        }
    }
}