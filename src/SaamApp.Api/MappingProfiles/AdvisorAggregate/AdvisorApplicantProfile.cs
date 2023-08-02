using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorApplicant;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorApplicantProfile : Profile
    {
        public AdvisorApplicantProfile()
        {
            CreateMap<AdvisorApplicant, AdvisorApplicantDto>();
            CreateMap<AdvisorApplicantDto, AdvisorApplicant>();
            CreateMap<CreateAdvisorApplicantRequest, AdvisorApplicant>();
            CreateMap<UpdateAdvisorApplicantRequest, AdvisorApplicant>();
            CreateMap<DeleteAdvisorApplicantRequest, AdvisorApplicant>();
        }
    }
}