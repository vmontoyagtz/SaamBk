using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitCreatedEvent : BaseDomainEvent
    {
        public BusinessUnitCreatedEvent(BusinessUnit businessUnit, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnit";
            Content = JsonConvert.SerializeObject(businessUnit, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}