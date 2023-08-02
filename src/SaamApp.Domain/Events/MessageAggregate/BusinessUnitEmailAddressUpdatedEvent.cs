using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitEmailAddressUpdatedEvent : BaseDomainEvent
    {
        public BusinessUnitEmailAddressUpdatedEvent(BusinessUnitEmailAddress businessUnitEmailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitEmailAddress";
            Content = JsonConvert.SerializeObject(businessUnitEmailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitEmailAddressUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}