using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorPaymentCreatedEvent : BaseDomainEvent
    {
        public AdvisorPaymentCreatedEvent(AdvisorPayment advisorPayment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorPayment";
            Content = JsonConvert.SerializeObject(advisorPayment, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorPaymentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}