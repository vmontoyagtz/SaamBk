using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerFeedbackProfile : Profile
    {
        public CustomerFeedbackProfile()
        {
            CreateMap<CustomerFeedback, CustomerFeedbackDto>();
            CreateMap<CustomerFeedbackDto, CustomerFeedback>();
            CreateMap<CreateCustomerFeedbackRequest, CustomerFeedback>();
            CreateMap<UpdateCustomerFeedbackRequest, CustomerFeedback>();
            CreateMap<DeleteCustomerFeedbackRequest, CustomerFeedback>();
        }
    }
}