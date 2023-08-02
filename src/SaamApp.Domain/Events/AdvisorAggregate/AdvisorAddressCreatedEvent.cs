using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorAddressCreatedEvent : BaseDomainEvent
    {
        public AdvisorAddressCreatedEvent(AdvisorAddress advisorAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorAddress";
            Content = JsonConvert.SerializeObject(advisorAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorAddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}