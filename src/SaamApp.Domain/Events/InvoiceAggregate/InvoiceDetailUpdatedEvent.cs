using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class InvoiceDetailUpdatedEvent : BaseDomainEvent
    {
        public InvoiceDetailUpdatedEvent(InvoiceDetail invoiceDetail, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "InvoiceDetail";
            Content = JsonConvert.SerializeObject(invoiceDetail, JsonSerializerSettingsSingleton.Instance);
            EventType = "InvoiceDetailUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}