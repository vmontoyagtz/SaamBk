using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PaymentFrequencyCreatedEvent : BaseDomainEvent
    {
        public PaymentFrequencyCreatedEvent(PaymentFrequency paymentFrequency, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PaymentFrequency";
            Content = JsonConvert.SerializeObject(paymentFrequency, JsonSerializerSettingsSingleton.Instance);
            EventType = "PaymentFrequencyCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}