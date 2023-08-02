using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiMemoryUpdatedEvent : BaseDomainEvent
    {
        public AiMemoryUpdatedEvent(AiMemory aiMemory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiMemory";
            Content = JsonConvert.SerializeObject(aiMemory, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiMemoryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}