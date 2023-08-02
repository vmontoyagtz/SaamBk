using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiRobot;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiRobotProfile : Profile
    {
        public AiRobotProfile()
        {
            CreateMap<AiRobot, AiRobotDto>();
            CreateMap<AiRobotDto, AiRobot>();
            CreateMap<CreateAiRobotRequest, AiRobot>();
            CreateMap<UpdateAiRobotRequest, AiRobot>();
            CreateMap<DeleteAiRobotRequest, AiRobot>();
        }
    }
}