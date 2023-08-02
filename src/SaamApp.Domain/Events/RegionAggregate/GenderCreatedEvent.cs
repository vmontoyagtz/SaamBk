using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class GenderCreatedEvent : BaseDomainEvent
    {
        public GenderCreatedEvent(Gender gender, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Gender";
            Content = JsonConvert.SerializeObject(gender, JsonSerializerSettingsSingleton.Instance);
            EventType = "GenderCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}