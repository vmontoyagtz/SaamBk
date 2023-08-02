using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class InvoiceDetailCreatedEvent : BaseDomainEvent
    {
        public InvoiceDetailCreatedEvent(InvoiceDetail invoiceDetail, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "InvoiceDetail";
            Content = JsonConvert.SerializeObject(invoiceDetail, JsonSerializerSettingsSingleton.Instance);
            EventType = "InvoiceDetailCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}