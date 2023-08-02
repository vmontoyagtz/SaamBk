using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitAddressCreatedEvent : BaseDomainEvent
    {
        public BusinessUnitAddressCreatedEvent(BusinessUnitAddress businessUnitAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitAddress";
            Content = JsonConvert.SerializeObject(businessUnitAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitAddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}