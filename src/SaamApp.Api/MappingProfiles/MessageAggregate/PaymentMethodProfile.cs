using AutoMapper;
using SaamApp.BlazorMauiShared.Models.PaymentMethod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<PaymentMethodDto, PaymentMethod>();
            CreateMap<CreatePaymentMethodRequest, PaymentMethod>();
            CreateMap<UpdatePaymentMethodRequest, PaymentMethod>();
            CreateMap<DeletePaymentMethodRequest, PaymentMethod>();
        }
    }
}