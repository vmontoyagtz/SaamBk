using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorUpdatedEvent : BaseDomainEvent
    {
        public AdvisorUpdatedEvent(Advisor advisor, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Advisor";
            Content = JsonConvert.SerializeObject(advisor, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}