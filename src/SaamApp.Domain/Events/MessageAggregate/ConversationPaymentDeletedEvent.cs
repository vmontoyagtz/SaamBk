using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ConversationPaymentDeletedEvent : BaseDomainEvent
    {
        public ConversationPaymentDeletedEvent(ConversationPayment conversationPayment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ConversationPayment";
            Content = JsonConvert.SerializeObject(conversationPayment, JsonSerializerSettingsSingleton.Instance);
            EventType = "ConversationPaymentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}