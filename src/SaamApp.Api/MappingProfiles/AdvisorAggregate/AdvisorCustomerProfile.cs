using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorCustomer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorCustomerProfile : Profile
    {
        public AdvisorCustomerProfile()
        {
            CreateMap<AdvisorCustomer, AdvisorCustomerDto>();
            CreateMap<AdvisorCustomerDto, AdvisorCustomer>();
            CreateMap<CreateAdvisorCustomerRequest, AdvisorCustomer>();
            CreateMap<UpdateAdvisorCustomerRequest, AdvisorCustomer>();
            CreateMap<DeleteAdvisorCustomerRequest, AdvisorCustomer>();
        }
    }
}