using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PaymentFrequencyDeletedEvent : BaseDomainEvent
    {
        public PaymentFrequencyDeletedEvent(PaymentFrequency paymentFrequency, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PaymentFrequency";
            Content = JsonConvert.SerializeObject(paymentFrequency, JsonSerializerSettingsSingleton.Instance);
            EventType = "PaymentFrequencyDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}