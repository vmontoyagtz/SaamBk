using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorAddressDeletedEvent : BaseDomainEvent
    {
        public AdvisorAddressDeletedEvent(AdvisorAddress advisorAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorAddress";
            Content = JsonConvert.SerializeObject(advisorAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorAddressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}