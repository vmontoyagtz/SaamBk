using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerPaymentProfile : Profile
    {
        public CustomerPaymentProfile()
        {
            CreateMap<CustomerPayment, CustomerPaymentDto>();
            CreateMap<CustomerPaymentDto, CustomerPayment>();
            CreateMap<CreateCustomerPaymentRequest, CustomerPayment>();
            CreateMap<UpdateCustomerPaymentRequest, CustomerPayment>();
            CreateMap<DeleteCustomerPaymentRequest, CustomerPayment>();
        }
    }
}