using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorAddressProfile : Profile
    {
        public AdvisorAddressProfile()
        {
            CreateMap<AdvisorAddress, AdvisorAddressDto>();
            CreateMap<AdvisorAddressDto, AdvisorAddress>();
            CreateMap<CreateAdvisorAddressRequest, AdvisorAddress>();
            CreateMap<UpdateAdvisorAddressRequest, AdvisorAddress>();
            CreateMap<DeleteAdvisorAddressRequest, AdvisorAddress>();
        }
    }
}