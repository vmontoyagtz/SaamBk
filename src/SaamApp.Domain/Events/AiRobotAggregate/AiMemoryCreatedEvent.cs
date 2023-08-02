using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiMemoryCreatedEvent : BaseDomainEvent
    {
        public AiMemoryCreatedEvent(AiMemory aiMemory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiMemory";
            Content = JsonConvert.SerializeObject(aiMemory, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiMemoryCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}