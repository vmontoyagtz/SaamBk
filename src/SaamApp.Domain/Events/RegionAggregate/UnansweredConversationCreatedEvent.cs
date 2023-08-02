using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class UnansweredConversationCreatedEvent : BaseDomainEvent
    {
        public UnansweredConversationCreatedEvent(UnansweredConversation unansweredConversation, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "UnansweredConversation";
            Content = JsonConvert.SerializeObject(unansweredConversation, JsonSerializerSettingsSingleton.Instance);
            EventType = "UnansweredConversationCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}