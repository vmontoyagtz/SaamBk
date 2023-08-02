using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerPaymentCreatedEvent : BaseDomainEvent
    {
        public CustomerPaymentCreatedEvent(CustomerPayment customerPayment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerPayment";
            Content = JsonConvert.SerializeObject(customerPayment, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerPaymentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}