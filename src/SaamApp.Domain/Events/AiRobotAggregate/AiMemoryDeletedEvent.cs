using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiMemoryDeletedEvent : BaseDomainEvent
    {
        public AiMemoryDeletedEvent(AiMemory aiMemory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiMemory";
            Content = JsonConvert.SerializeObject(aiMemory, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiMemoryDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}