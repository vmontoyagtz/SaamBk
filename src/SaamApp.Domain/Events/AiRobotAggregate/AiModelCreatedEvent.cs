using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiModelCreatedEvent : BaseDomainEvent
    {
        public AiModelCreatedEvent(AiModel aiModel, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiModel";
            Content = JsonConvert.SerializeObject(aiModel, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiModelCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}