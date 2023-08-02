using AutoMapper;
using SaamApp.BlazorMauiShared.Models.PaymentFrequency;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class PaymentFrequencyProfile : Profile
    {
        public PaymentFrequencyProfile()
        {
            CreateMap<PaymentFrequency, PaymentFrequencyDto>();
            CreateMap<PaymentFrequencyDto, PaymentFrequency>();
            CreateMap<CreatePaymentFrequencyRequest, PaymentFrequency>();
            CreateMap<UpdatePaymentFrequencyRequest, PaymentFrequency>();
            CreateMap<DeletePaymentFrequencyRequest, PaymentFrequency>();
        }
    }
}