using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiAreaExpertiseDeletedEvent : BaseDomainEvent
    {
        public AiAreaExpertiseDeletedEvent(AiAreaExpertise aiAreaExpertise, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiAreaExpertise";
            Content = JsonConvert.SerializeObject(aiAreaExpertise, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiAreaExpertiseDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}