using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitDeletedEvent : BaseDomainEvent
    {
        public BusinessUnitDeletedEvent(BusinessUnit businessUnit, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnit";
            Content = JsonConvert.SerializeObject(businessUnit, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}