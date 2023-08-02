using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ConversationStageDeletedEvent : BaseDomainEvent
    {
        public ConversationStageDeletedEvent(ConversationStage conversationStage, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ConversationStage";
            Content = JsonConvert.SerializeObject(conversationStage, JsonSerializerSettingsSingleton.Instance);
            EventType = "ConversationStageDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}