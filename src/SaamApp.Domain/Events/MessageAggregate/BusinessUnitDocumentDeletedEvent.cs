using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitDocumentDeletedEvent : BaseDomainEvent
    {
        public BusinessUnitDocumentDeletedEvent(BusinessUnitDocument businessUnitDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitDocument";
            Content = JsonConvert.SerializeObject(businessUnitDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitDocumentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}