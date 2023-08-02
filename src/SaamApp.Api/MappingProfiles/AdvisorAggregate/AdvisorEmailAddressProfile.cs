using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorEmailAddressProfile : Profile
    {
        public AdvisorEmailAddressProfile()
        {
            CreateMap<AdvisorEmailAddress, AdvisorEmailAddressDto>();
            CreateMap<AdvisorEmailAddressDto, AdvisorEmailAddress>();
            CreateMap<CreateAdvisorEmailAddressRequest, AdvisorEmailAddress>();
            CreateMap<UpdateAdvisorEmailAddressRequest, AdvisorEmailAddress>();
            CreateMap<DeleteAdvisorEmailAddressRequest, AdvisorEmailAddress>();
        }
    }
}