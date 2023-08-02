using AutoMapper;
using SaamApp.BlazorMauiShared.Models.MessageType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class MessageTypeProfile : Profile
    {
        public MessageTypeProfile()
        {
            CreateMap<MessageType, MessageTypeDto>();
            CreateMap<MessageTypeDto, MessageType>();
            CreateMap<CreateMessageTypeRequest, MessageType>();
            CreateMap<UpdateMessageTypeRequest, MessageType>();
            CreateMap<DeleteMessageTypeRequest, MessageType>();
        }
    }
}