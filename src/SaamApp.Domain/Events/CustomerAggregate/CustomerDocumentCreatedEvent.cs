using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerDocumentCreatedEvent : BaseDomainEvent
    {
        public CustomerDocumentCreatedEvent(CustomerDocument customerDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerDocument";
            Content = JsonConvert.SerializeObject(customerDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerDocumentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}