using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorDocumentProfile : Profile
    {
        public AdvisorDocumentProfile()
        {
            CreateMap<AdvisorDocument, AdvisorDocumentDto>();
            CreateMap<AdvisorDocumentDto, AdvisorDocument>();
            CreateMap<CreateAdvisorDocumentRequest, AdvisorDocument>();
            CreateMap<UpdateAdvisorDocumentRequest, AdvisorDocument>();
            CreateMap<DeleteAdvisorDocumentRequest, AdvisorDocument>();
        }
    }
}