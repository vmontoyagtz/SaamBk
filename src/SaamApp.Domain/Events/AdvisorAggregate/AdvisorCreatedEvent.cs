using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorCreatedEvent : BaseDomainEvent
    {
        public AdvisorCreatedEvent(Advisor advisor, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Advisor";
            Content = JsonConvert.SerializeObject(advisor, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}