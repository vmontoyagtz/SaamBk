using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerPurchase;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerPurchaseProfile : Profile
    {
        public CustomerPurchaseProfile()
        {
            CreateMap<CustomerPurchase, CustomerPurchaseDto>();
            CreateMap<CustomerPurchaseDto, CustomerPurchase>();
            CreateMap<CreateCustomerPurchaseRequest, CustomerPurchase>();
            CreateMap<UpdateCustomerPurchaseRequest, CustomerPurchase>();
            CreateMap<DeleteCustomerPurchaseRequest, CustomerPurchase>();
        }
    }
}