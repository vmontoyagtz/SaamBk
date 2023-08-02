using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorLoginUpdatedEvent : BaseDomainEvent
    {
        public AdvisorLoginUpdatedEvent(AdvisorLogin advisorLogin, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorLogin";
            Content = JsonConvert.SerializeObject(advisorLogin, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorLoginUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}