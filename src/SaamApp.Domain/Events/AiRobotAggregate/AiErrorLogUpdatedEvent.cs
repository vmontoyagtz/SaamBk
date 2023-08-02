using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiErrorLogUpdatedEvent : BaseDomainEvent
    {
        public AiErrorLogUpdatedEvent(AiErrorLog aiErrorLog, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiErrorLog";
            Content = JsonConvert.SerializeObject(aiErrorLog, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiErrorLogUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}