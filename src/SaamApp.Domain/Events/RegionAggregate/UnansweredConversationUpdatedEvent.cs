using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class UnansweredConversationUpdatedEvent : BaseDomainEvent
    {
        public UnansweredConversationUpdatedEvent(UnansweredConversation unansweredConversation, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "UnansweredConversation";
            Content = JsonConvert.SerializeObject(unansweredConversation, JsonSerializerSettingsSingleton.Instance);
            EventType = "UnansweredConversationUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}