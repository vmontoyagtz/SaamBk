using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PaymentMethodDeletedEvent : BaseDomainEvent
    {
        public PaymentMethodDeletedEvent(PaymentMethod paymentMethod, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PaymentMethod";
            Content = JsonConvert.SerializeObject(paymentMethod, JsonSerializerSettingsSingleton.Instance);
            EventType = "PaymentMethodDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}