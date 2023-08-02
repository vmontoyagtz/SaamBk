using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TemplateCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TemplateCategoryProfile : Profile
    {
        public TemplateCategoryProfile()
        {
            CreateMap<TemplateCategory, TemplateCategoryDto>();
            CreateMap<TemplateCategoryDto, TemplateCategory>();
            CreateMap<CreateTemplateCategoryRequest, TemplateCategory>();
            CreateMap<UpdateTemplateCategoryRequest, TemplateCategory>();
            CreateMap<DeleteTemplateCategoryRequest, TemplateCategory>();
        }
    }
}