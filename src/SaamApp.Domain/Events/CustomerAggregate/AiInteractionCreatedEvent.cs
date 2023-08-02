using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiInteractionCreatedEvent : BaseDomainEvent
    {
        public AiInteractionCreatedEvent(AiInteraction aiInteraction, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiInteraction";
            Content = JsonConvert.SerializeObject(aiInteraction, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiInteractionCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}