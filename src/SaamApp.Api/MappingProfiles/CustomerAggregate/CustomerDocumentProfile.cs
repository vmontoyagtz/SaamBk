using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerDocumentProfile : Profile
    {
        public CustomerDocumentProfile()
        {
            CreateMap<CustomerDocument, CustomerDocumentDto>();
            CreateMap<CustomerDocumentDto, CustomerDocument>();
            CreateMap<CreateCustomerDocumentRequest, CustomerDocument>();
            CreateMap<UpdateCustomerDocumentRequest, CustomerDocument>();
            CreateMap<DeleteCustomerDocumentRequest, CustomerDocument>();
        }
    }
}