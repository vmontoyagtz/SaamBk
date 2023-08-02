using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class InteractionTypeDeletedEvent : BaseDomainEvent
    {
        public InteractionTypeDeletedEvent(InteractionType interactionType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "InteractionType";
            Content = JsonConvert.SerializeObject(interactionType, JsonSerializerSettingsSingleton.Instance);
            EventType = "InteractionTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}