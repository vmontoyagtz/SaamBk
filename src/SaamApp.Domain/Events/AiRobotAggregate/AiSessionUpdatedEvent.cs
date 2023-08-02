using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiSessionUpdatedEvent : BaseDomainEvent
    {
        public AiSessionUpdatedEvent(AiSession aiSession, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiSession";
            Content = JsonConvert.SerializeObject(aiSession, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiSessionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}