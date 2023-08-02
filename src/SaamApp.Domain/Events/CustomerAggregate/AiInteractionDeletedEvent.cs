using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AiInteractionDeletedEvent : BaseDomainEvent
    {
        public AiInteractionDeletedEvent(AiInteraction aiInteraction, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AiInteraction";
            Content = JsonConvert.SerializeObject(aiInteraction, JsonSerializerSettingsSingleton.Instance);
            EventType = "AiInteractionDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}