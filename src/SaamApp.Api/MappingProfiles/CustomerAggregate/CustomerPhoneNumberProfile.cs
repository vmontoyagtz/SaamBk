using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerPhoneNumberProfile : Profile
    {
        public CustomerPhoneNumberProfile()
        {
            CreateMap<CustomerPhoneNumber, CustomerPhoneNumberDto>();
            CreateMap<CustomerPhoneNumberDto, CustomerPhoneNumber>();
            CreateMap<CreateCustomerPhoneNumberRequest, CustomerPhoneNumber>();
            CreateMap<UpdateCustomerPhoneNumberRequest, CustomerPhoneNumber>();
            CreateMap<DeleteCustomerPhoneNumberRequest, CustomerPhoneNumber>();
        }
    }
}