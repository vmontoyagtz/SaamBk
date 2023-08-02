using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorIdentityDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorIdentityDocumentProfile : Profile
    {
        public AdvisorIdentityDocumentProfile()
        {
            CreateMap<AdvisorIdentityDocument, AdvisorIdentityDocumentDto>();
            CreateMap<AdvisorIdentityDocumentDto, AdvisorIdentityDocument>();
            CreateMap<CreateAdvisorIdentityDocumentRequest, AdvisorIdentityDocument>();
            CreateMap<UpdateAdvisorIdentityDocumentRequest, AdvisorIdentityDocument>();
            CreateMap<DeleteAdvisorIdentityDocumentRequest, AdvisorIdentityDocument>();
        }
    }
}