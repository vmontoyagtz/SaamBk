using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiModelDeletedEvent : BaseDomainEvent
    {
        public AiModelDeletedEvent(AiModel aiModel, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiModel";
            Content = JsonConvert.SerializeObject(aiModel, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiModelDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}