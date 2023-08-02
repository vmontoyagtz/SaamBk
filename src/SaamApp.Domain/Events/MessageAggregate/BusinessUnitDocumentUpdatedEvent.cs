using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitDocumentUpdatedEvent : BaseDomainEvent
    {
        public BusinessUnitDocumentUpdatedEvent(BusinessUnitDocument businessUnitDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitDocument";
            Content = JsonConvert.SerializeObject(businessUnitDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitDocumentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}