using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Template;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            CreateMap<Template, TemplateDto>();
            CreateMap<TemplateDto, Template>();
            CreateMap<CreateTemplateRequest, Template>();
            CreateMap<UpdateTemplateRequest, Template>();
            CreateMap<DeleteTemplateRequest, Template>();
        }
    }
}