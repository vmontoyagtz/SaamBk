using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorEmailAddressDeletedEvent : BaseDomainEvent
    {
        public AdvisorEmailAddressDeletedEvent(AdvisorEmailAddress advisorEmailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorEmailAddress";
            Content = JsonConvert.SerializeObject(advisorEmailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorEmailAddressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}