using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class GenderUpdatedEvent : BaseDomainEvent
    {
        public GenderUpdatedEvent(Gender gender, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Gender";
            Content = JsonConvert.SerializeObject(gender, JsonSerializerSettingsSingleton.Instance);
            EventType = "GenderUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}