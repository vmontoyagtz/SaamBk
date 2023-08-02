using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiInteractionUpdatedEvent : BaseDomainEvent
    {
        public AiInteractionUpdatedEvent(AiInteraction aiInteraction, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiInteraction";
            Content = JsonConvert.SerializeObject(aiInteraction, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiInteractionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}