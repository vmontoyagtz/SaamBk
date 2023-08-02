using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class InteractionTypeCreatedEvent : BaseDomainEvent
    {
        public InteractionTypeCreatedEvent(InteractionType interactionType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "InteractionType";
            Content = JsonConvert.SerializeObject(interactionType, JsonSerializerSettingsSingleton.Instance);
            EventType = "InteractionTypeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}