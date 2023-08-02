using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerAiHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerAiHistoryProfile : Profile
    {
        public CustomerAiHistoryProfile()
        {
            CreateMap<CustomerAiHistory, CustomerAiHistoryDto>();
            CreateMap<CustomerAiHistoryDto, CustomerAiHistory>();
            CreateMap<CreateCustomerAiHistoryRequest, CustomerAiHistory>();
            CreateMap<UpdateCustomerAiHistoryRequest, CustomerAiHistory>();
            CreateMap<DeleteCustomerAiHistoryRequest, CustomerAiHistory>();
        }
    }
}