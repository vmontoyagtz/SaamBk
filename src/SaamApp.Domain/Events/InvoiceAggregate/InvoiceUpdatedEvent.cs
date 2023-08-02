using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class InvoiceUpdatedEvent : BaseDomainEvent
    {
        public InvoiceUpdatedEvent(Invoice invoice, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Invoice";
            Content = JsonConvert.SerializeObject(invoice, JsonSerializerSettingsSingleton.Instance);
            EventType = "InvoiceUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}