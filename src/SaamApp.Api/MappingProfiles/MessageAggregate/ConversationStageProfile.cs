using AutoMapper;
using SaamApp.BlazorMauiShared.Models.ConversationStage;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class ConversationStageProfile : Profile
    {
        public ConversationStageProfile()
        {
            CreateMap<ConversationStage, ConversationStageDto>();
            CreateMap<ConversationStageDto, ConversationStage>();
            CreateMap<CreateConversationStageRequest, ConversationStage>();
            CreateMap<UpdateConversationStageRequest, ConversationStage>();
            CreateMap<DeleteConversationStageRequest, ConversationStage>();
        }
    }
}