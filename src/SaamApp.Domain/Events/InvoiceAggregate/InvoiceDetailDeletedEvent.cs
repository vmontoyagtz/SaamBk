using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class InvoiceDetailDeletedEvent : BaseDomainEvent
    {
        public InvoiceDetailDeletedEvent(InvoiceDetail invoiceDetail, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "InvoiceDetail";
            Content = JsonConvert.SerializeObject(invoiceDetail, JsonSerializerSettingsSingleton.Instance);
            EventType = "InvoiceDetailDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}