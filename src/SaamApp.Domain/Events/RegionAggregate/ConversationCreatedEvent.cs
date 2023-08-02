using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ConversationCreatedEvent : BaseDomainEvent
    {
        public ConversationCreatedEvent(Conversation conversation, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Conversation";
            Content = JsonConvert.SerializeObject(conversation, JsonSerializerSettingsSingleton.Instance);
            EventType = "ConversationCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}