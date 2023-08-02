using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerEmailAddressProfile : Profile
    {
        public CustomerEmailAddressProfile()
        {
            CreateMap<CustomerEmailAddress, CustomerEmailAddressDto>();
            CreateMap<CustomerEmailAddressDto, CustomerEmailAddress>();
            CreateMap<CreateCustomerEmailAddressRequest, CustomerEmailAddress>();
            CreateMap<UpdateCustomerEmailAddressRequest, CustomerEmailAddress>();
            CreateMap<DeleteCustomerEmailAddressRequest, CustomerEmailAddress>();
        }
    }
}