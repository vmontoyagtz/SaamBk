using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorPhoneNumberProfile : Profile
    {
        public AdvisorPhoneNumberProfile()
        {
            CreateMap<AdvisorPhoneNumber, AdvisorPhoneNumberDto>();
            CreateMap<AdvisorPhoneNumberDto, AdvisorPhoneNumber>();
            CreateMap<CreateAdvisorPhoneNumberRequest, AdvisorPhoneNumber>();
            CreateMap<UpdateAdvisorPhoneNumberRequest, AdvisorPhoneNumber>();
            CreateMap<DeleteAdvisorPhoneNumberRequest, AdvisorPhoneNumber>();
        }
    }
}