using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorLogin;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorLoginProfile : Profile
    {
        public AdvisorLoginProfile()
        {
            CreateMap<AdvisorLogin, AdvisorLoginDto>();
            CreateMap<AdvisorLoginDto, AdvisorLogin>();
            CreateMap<CreateAdvisorLoginRequest, AdvisorLogin>();
            CreateMap<UpdateAdvisorLoginRequest, AdvisorLogin>();
            CreateMap<DeleteAdvisorLoginRequest, AdvisorLogin>();
        }
    }
}