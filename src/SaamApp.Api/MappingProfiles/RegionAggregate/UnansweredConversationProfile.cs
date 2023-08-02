using AutoMapper;
using SaamApp.BlazorMauiShared.Models.UnansweredConversation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class UnansweredConversationProfile : Profile
    {
        public UnansweredConversationProfile()
        {
            CreateMap<UnansweredConversation, UnansweredConversationDto>();
            CreateMap<UnansweredConversationDto, UnansweredConversation>();
            CreateMap<CreateUnansweredConversationRequest, UnansweredConversation>();
            CreateMap<UpdateUnansweredConversationRequest, UnansweredConversation>();
            CreateMap<DeleteUnansweredConversationRequest, UnansweredConversation>();
        }
    }
}