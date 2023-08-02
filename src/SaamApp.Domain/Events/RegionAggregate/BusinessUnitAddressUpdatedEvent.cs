using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitAddressUpdatedEvent : BaseDomainEvent
    {
        public BusinessUnitAddressUpdatedEvent(BusinessUnitAddress businessUnitAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitAddress";
            Content = JsonConvert.SerializeObject(businessUnitAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitAddressUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}