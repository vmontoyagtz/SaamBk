using AutoMapper;
using SaamApp.BlazorMauiShared.Models.MessageDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class MessageDocumentProfile : Profile
    {
        public MessageDocumentProfile()
        {
            CreateMap<MessageDocument, MessageDocumentDto>();
            CreateMap<MessageDocumentDto, MessageDocument>();
            CreateMap<CreateMessageDocumentRequest, MessageDocument>();
            CreateMap<UpdateMessageDocumentRequest, MessageDocument>();
            CreateMap<DeleteMessageDocumentRequest, MessageDocument>();
        }
    }
}