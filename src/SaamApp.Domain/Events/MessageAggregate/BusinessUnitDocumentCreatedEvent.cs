using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitDocumentCreatedEvent : BaseDomainEvent
    {
        public BusinessUnitDocumentCreatedEvent(BusinessUnitDocument businessUnitDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitDocument";
            Content = JsonConvert.SerializeObject(businessUnitDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitDocumentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}