using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiAreaExpertiseUpdatedEvent : BaseDomainEvent
    {
        public AiAreaExpertiseUpdatedEvent(AiAreaExpertise aiAreaExpertise, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiAreaExpertise";
            Content = JsonConvert.SerializeObject(aiAreaExpertise, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiAreaExpertiseUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}