using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class SerfinsaPaymentDeletedEvent : BaseDomainEvent
    {
        public SerfinsaPaymentDeletedEvent(SerfinsaPayment serfinsaPayment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "SerfinsaPayment";
            Content = JsonConvert.SerializeObject(serfinsaPayment, JsonSerializerSettingsSingleton.Instance);
            EventType = "SerfinsaPaymentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}