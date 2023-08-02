using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TemplateDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TemplateDocumentProfile : Profile
    {
        public TemplateDocumentProfile()
        {
            CreateMap<TemplateDocument, TemplateDocumentDto>();
            CreateMap<TemplateDocumentDto, TemplateDocument>();
            CreateMap<CreateTemplateDocumentRequest, TemplateDocument>();
            CreateMap<UpdateTemplateDocumentRequest, TemplateDocument>();
            CreateMap<DeleteTemplateDocumentRequest, TemplateDocument>();
        }
    }
}