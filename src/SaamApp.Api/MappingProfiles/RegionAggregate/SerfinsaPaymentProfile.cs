using AutoMapper;
using SaamApp.BlazorMauiShared.Models.SerfinsaPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class SerfinsaPaymentProfile : Profile
    {
        public SerfinsaPaymentProfile()
        {
            CreateMap<SerfinsaPayment, SerfinsaPaymentDto>();
            CreateMap<SerfinsaPaymentDto, SerfinsaPayment>();
            CreateMap<CreateSerfinsaPaymentRequest, SerfinsaPayment>();
            CreateMap<UpdateSerfinsaPaymentRequest, SerfinsaPayment>();
            CreateMap<DeleteSerfinsaPaymentRequest, SerfinsaPayment>();
        }
    }
}