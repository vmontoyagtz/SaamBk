using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class SerfinsaPaymentUpdatedEvent : BaseDomainEvent
    {
        public SerfinsaPaymentUpdatedEvent(SerfinsaPayment serfinsaPayment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "SerfinsaPayment";
            Content = JsonConvert.SerializeObject(serfinsaPayment, JsonSerializerSettingsSingleton.Instance);
            EventType = "SerfinsaPaymentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}