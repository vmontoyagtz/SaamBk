using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorBank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorBankProfile : Profile
    {
        public AdvisorBankProfile()
        {
            CreateMap<AdvisorBank, AdvisorBankDto>();
            CreateMap<AdvisorBankDto, AdvisorBank>();
            CreateMap<CreateAdvisorBankRequest, AdvisorBank>();
            CreateMap<UpdateAdvisorBankRequest, AdvisorBank>();
            CreateMap<DeleteAdvisorBankRequest, AdvisorBank>();
        }
    }
}