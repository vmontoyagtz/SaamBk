using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Conversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class ConversationProfile : Profile
    {
        public ConversationProfile()
        {
            CreateMap<Conversation, ConversationDto>();
            CreateMap<ConversationDto, Conversation>();
            CreateMap<CreateConversationRequest, Conversation>();
            CreateMap<UpdateConversationRequest, Conversation>();
            CreateMap<DeleteConversationRequest, Conversation>();
        }
    }
}