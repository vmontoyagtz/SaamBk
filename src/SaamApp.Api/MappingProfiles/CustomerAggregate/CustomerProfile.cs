using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<DeleteCustomerRequest, Customer>();
        }
    }
}