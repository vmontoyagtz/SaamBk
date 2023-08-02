using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerAddressProfile : Profile
    {
        public CustomerAddressProfile()
        {
            CreateMap<CustomerAddress, CustomerAddressDto>();
            CreateMap<CustomerAddressDto, CustomerAddress>();
            CreateMap<CreateCustomerAddressRequest, CustomerAddress>();
            CreateMap<UpdateCustomerAddressRequest, CustomerAddress>();
            CreateMap<DeleteCustomerAddressRequest, CustomerAddress>();
        }
    }
}