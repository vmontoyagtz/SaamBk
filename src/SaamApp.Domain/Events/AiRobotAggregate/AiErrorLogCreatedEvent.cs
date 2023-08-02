using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiErrorLogCreatedEvent : BaseDomainEvent
    {
        public AiErrorLogCreatedEvent(AiErrorLog aiErrorLog, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiErrorLog";
            Content = JsonConvert.SerializeObject(aiErrorLog, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiErrorLogCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}