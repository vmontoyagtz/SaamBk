using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitAddressDeletedEvent : BaseDomainEvent
    {
        public BusinessUnitAddressDeletedEvent(BusinessUnitAddress businessUnitAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitAddress";
            Content = JsonConvert.SerializeObject(businessUnitAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitAddressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}