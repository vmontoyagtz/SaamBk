using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Message;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();
            CreateMap<CreateMessageRequest, Message>();
            CreateMap<UpdateMessageRequest, Message>();
            CreateMap<DeleteMessageRequest, Message>();
        }
    }
}