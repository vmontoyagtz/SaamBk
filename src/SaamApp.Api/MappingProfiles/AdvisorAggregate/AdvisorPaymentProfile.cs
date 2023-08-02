using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorPaymentProfile : Profile
    {
        public AdvisorPaymentProfile()
        {
            CreateMap<AdvisorPayment, AdvisorPaymentDto>();
            CreateMap<AdvisorPaymentDto, AdvisorPayment>();
            CreateMap<CreateAdvisorPaymentRequest, AdvisorPayment>();
            CreateMap<UpdateAdvisorPaymentRequest, AdvisorPayment>();
            CreateMap<DeleteAdvisorPaymentRequest, AdvisorPayment>();
        }
    }
}