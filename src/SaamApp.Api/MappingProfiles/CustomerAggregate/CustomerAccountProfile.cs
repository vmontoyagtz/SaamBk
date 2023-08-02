using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerAccountProfile : Profile
    {
        public CustomerAccountProfile()
        {
            CreateMap<CustomerAccount, CustomerAccountDto>();
            CreateMap<CustomerAccountDto, CustomerAccount>();
            CreateMap<CreateCustomerAccountRequest, CustomerAccount>();
            CreateMap<UpdateCustomerAccountRequest, CustomerAccount>();
            CreateMap<DeleteCustomerAccountRequest, CustomerAccount>();
        }
    }
}