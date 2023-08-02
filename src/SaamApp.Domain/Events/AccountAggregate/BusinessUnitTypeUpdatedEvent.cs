using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitTypeUpdatedEvent : BaseDomainEvent
    {
        public BusinessUnitTypeUpdatedEvent(BusinessUnitType businessUnitType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitType";
            Content = JsonConvert.SerializeObject(businessUnitType, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitTypeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}