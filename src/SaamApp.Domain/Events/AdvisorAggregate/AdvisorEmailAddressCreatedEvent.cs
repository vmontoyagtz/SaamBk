using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorEmailAddressCreatedEvent : BaseDomainEvent
    {
        public AdvisorEmailAddressCreatedEvent(AdvisorEmailAddress advisorEmailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorEmailAddress";
            Content = JsonConvert.SerializeObject(advisorEmailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorEmailAddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}