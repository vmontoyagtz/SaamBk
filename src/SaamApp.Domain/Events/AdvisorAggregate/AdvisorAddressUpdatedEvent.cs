using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorAddressUpdatedEvent : BaseDomainEvent
    {
        public AdvisorAddressUpdatedEvent(AdvisorAddress advisorAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorAddress";
            Content = JsonConvert.SerializeObject(advisorAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorAddressUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}