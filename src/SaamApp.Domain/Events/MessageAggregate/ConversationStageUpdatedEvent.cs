using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ConversationStageUpdatedEvent : BaseDomainEvent
    {
        public ConversationStageUpdatedEvent(ConversationStage conversationStage, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ConversationStage";
            Content = JsonConvert.SerializeObject(conversationStage, JsonSerializerSettingsSingleton.Instance);
            EventType = "ConversationStageUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}