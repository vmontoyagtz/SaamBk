using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiModelUpdatedEvent : BaseDomainEvent
    {
        public AiModelUpdatedEvent(AiModel aiModel, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiModel";
            Content = JsonConvert.SerializeObject(aiModel, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiModelUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}