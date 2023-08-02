using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ConversationPaymentCreatedEvent : BaseDomainEvent
    {
        public ConversationPaymentCreatedEvent(ConversationPayment conversationPayment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ConversationPayment";
            Content = JsonConvert.SerializeObject(conversationPayment, JsonSerializerSettingsSingleton.Instance);
            EventType = "ConversationPaymentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}