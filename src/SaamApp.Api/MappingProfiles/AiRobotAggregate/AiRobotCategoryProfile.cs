using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiRobotCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiRobotCategoryProfile : Profile
    {
        public AiRobotCategoryProfile()
        {
            CreateMap<AiRobotCategory, AiRobotCategoryDto>();
            CreateMap<AiRobotCategoryDto, AiRobotCategory>();
            CreateMap<CreateAiRobotCategoryRequest, AiRobotCategory>();
            CreateMap<UpdateAiRobotCategoryRequest, AiRobotCategory>();
            CreateMap<DeleteAiRobotCategoryRequest, AiRobotCategory>();
        }
    }
}