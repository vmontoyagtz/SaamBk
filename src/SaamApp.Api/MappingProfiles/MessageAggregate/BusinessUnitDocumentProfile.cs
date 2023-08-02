using AutoMapper;
using SaamApp.BlazorMauiShared.Models.BusinessUnitDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BusinessUnitDocumentProfile : Profile
    {
        public BusinessUnitDocumentProfile()
        {
            CreateMap<BusinessUnitDocument, BusinessUnitDocumentDto>();
            CreateMap<BusinessUnitDocumentDto, BusinessUnitDocument>();
            CreateMap<CreateBusinessUnitDocumentRequest, BusinessUnitDocument>();
            CreateMap<UpdateBusinessUnitDocumentRequest, BusinessUnitDocument>();
            CreateMap<DeleteBusinessUnitDocumentRequest, BusinessUnitDocument>();
        }
    }
}