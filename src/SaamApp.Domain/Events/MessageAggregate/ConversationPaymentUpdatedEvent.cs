using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ConversationPaymentUpdatedEvent : BaseDomainEvent
    {
        public ConversationPaymentUpdatedEvent(ConversationPayment conversationPayment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ConversationPayment";
            Content = JsonConvert.SerializeObject(conversationPayment, JsonSerializerSettingsSingleton.Instance);
            EventType = "ConversationPaymentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}