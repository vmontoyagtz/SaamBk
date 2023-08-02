using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class InteractionTypeUpdatedEvent : BaseDomainEvent
    {
        public InteractionTypeUpdatedEvent(InteractionType interactionType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "InteractionType";
            Content = JsonConvert.SerializeObject(interactionType, JsonSerializerSettingsSingleton.Instance);
            EventType = "InteractionTypeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}