using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorLoginDeletedEvent : BaseDomainEvent
    {
        public AdvisorLoginDeletedEvent(AdvisorLogin advisorLogin, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorLogin";
            Content = JsonConvert.SerializeObject(advisorLogin, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorLoginDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}