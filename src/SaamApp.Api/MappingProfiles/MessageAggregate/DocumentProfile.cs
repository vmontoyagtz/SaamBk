using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Document;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentDto, Document>();
            CreateMap<CreateDocumentRequest, Document>();
            CreateMap<UpdateDocumentRequest, Document>();
            CreateMap<DeleteDocumentRequest, Document>();
        }
    }
}