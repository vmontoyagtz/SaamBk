using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitTypeDeletedEvent : BaseDomainEvent
    {
        public BusinessUnitTypeDeletedEvent(BusinessUnitType businessUnitType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitType";
            Content = JsonConvert.SerializeObject(businessUnitType, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}