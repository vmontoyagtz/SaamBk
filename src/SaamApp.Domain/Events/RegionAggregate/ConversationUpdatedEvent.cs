using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ConversationUpdatedEvent : BaseDomainEvent
    {
        public ConversationUpdatedEvent(Conversation conversation, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Conversation";
            Content = JsonConvert.SerializeObject(conversation, JsonSerializerSettingsSingleton.Instance);
            EventType = "ConversationUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}