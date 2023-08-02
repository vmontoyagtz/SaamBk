using AutoMapper;
using SaamApp.BlazorMauiShared.Models.ConversationPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class ConversationPaymentProfile : Profile
    {
        public ConversationPaymentProfile()
        {
            CreateMap<ConversationPayment, ConversationPaymentDto>();
            CreateMap<ConversationPaymentDto, ConversationPayment>();
            CreateMap<CreateConversationPaymentRequest, ConversationPayment>();
            CreateMap<UpdateConversationPaymentRequest, ConversationPayment>();
            CreateMap<DeleteConversationPaymentRequest, ConversationPayment>();
        }
    }
}