using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiErrorLogDeletedEvent : BaseDomainEvent
    {
        public AiErrorLogDeletedEvent(AiErrorLog aiErrorLog, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiErrorLog";
            Content = JsonConvert.SerializeObject(aiErrorLog, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiErrorLogDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}