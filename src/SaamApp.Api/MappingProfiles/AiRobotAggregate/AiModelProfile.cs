using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiModel;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiModelProfile : Profile
    {
        public AiModelProfile()
        {
            CreateMap<AiModel, AiModelDto>();
            CreateMap<AiModelDto, AiModel>();
            CreateMap<CreateAiModelRequest, AiModel>();
            CreateMap<UpdateAiModelRequest, AiModel>();
            CreateMap<DeleteAiModelRequest, AiModel>();
        }
    }
}