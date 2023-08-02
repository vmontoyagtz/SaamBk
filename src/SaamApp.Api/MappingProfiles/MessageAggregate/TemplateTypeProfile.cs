using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TemplateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TemplateTypeProfile : Profile
    {
        public TemplateTypeProfile()
        {
            CreateMap<TemplateType, TemplateTypeDto>();
            CreateMap<TemplateTypeDto, TemplateType>();
            CreateMap<CreateTemplateTypeRequest, TemplateType>();
            CreateMap<UpdateTemplateTypeRequest, TemplateType>();
            CreateMap<DeleteTemplateTypeRequest, TemplateType>();
        }
    }
}