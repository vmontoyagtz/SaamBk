using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class InvoiceDeletedEvent : BaseDomainEvent
    {
        public InvoiceDeletedEvent(Invoice invoice, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Invoice";
            Content = JsonConvert.SerializeObject(invoice, JsonSerializerSettingsSingleton.Instance);
            EventType = "InvoiceDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}