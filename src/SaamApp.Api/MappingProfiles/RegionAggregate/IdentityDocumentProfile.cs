using AutoMapper;
using SaamApp.BlazorMauiShared.Models.IdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class IdentityDocumentProfile : Profile
    {
        public IdentityDocumentProfile()
        {
            CreateMap<IdentityDocument, IdentityDocumentDto>();
            CreateMap<IdentityDocumentDto, IdentityDocument>();
            CreateMap<CreateIdentityDocumentRequest, IdentityDocument>();
            CreateMap<UpdateIdentityDocumentRequest, IdentityDocument>();
            CreateMap<DeleteIdentityDocumentRequest, IdentityDocument>();
        }
    }
}