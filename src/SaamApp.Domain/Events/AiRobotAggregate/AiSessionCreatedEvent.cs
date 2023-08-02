using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiSessionCreatedEvent : BaseDomainEvent
    {
        public AiSessionCreatedEvent(AiSession aiSession, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiSession";
            Content = JsonConvert.SerializeObject(aiSession, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiSessionCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}