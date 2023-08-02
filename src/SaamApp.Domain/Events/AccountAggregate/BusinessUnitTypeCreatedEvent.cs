using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitTypeCreatedEvent : BaseDomainEvent
    {
        public BusinessUnitTypeCreatedEvent(BusinessUnitType businessUnitType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitType";
            Content = JsonConvert.SerializeObject(businessUnitType, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitTypeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}