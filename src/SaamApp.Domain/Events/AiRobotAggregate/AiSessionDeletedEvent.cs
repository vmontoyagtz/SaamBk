using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiSessionDeletedEvent : BaseDomainEvent
    {
        public AiSessionDeletedEvent(AiSession aiSession, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiSession";
            Content = JsonConvert.SerializeObject(aiSession, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiSessionDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}