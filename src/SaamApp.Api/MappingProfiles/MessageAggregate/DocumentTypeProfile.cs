using AutoMapper;
using SaamApp.BlazorMauiShared.Models.DocumentType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<DocumentTypeDto, DocumentType>();
            CreateMap<CreateDocumentTypeRequest, DocumentType>();
            CreateMap<UpdateDocumentTypeRequest, DocumentType>();
            CreateMap<DeleteDocumentTypeRequest, DocumentType>();
        }
    }
}