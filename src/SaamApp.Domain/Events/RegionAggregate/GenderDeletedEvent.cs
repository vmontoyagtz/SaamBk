using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class GenderDeletedEvent : BaseDomainEvent
    {
        public GenderDeletedEvent(Gender gender, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Gender";
            Content = JsonConvert.SerializeObject(gender, JsonSerializerSettingsSingleton.Instance);
            EventType = "GenderDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}