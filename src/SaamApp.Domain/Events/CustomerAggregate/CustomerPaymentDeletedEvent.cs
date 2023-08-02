using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerPaymentDeletedEvent : BaseDomainEvent
    {
        public CustomerPaymentDeletedEvent(CustomerPayment customerPayment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerPayment";
            Content = JsonConvert.SerializeObject(customerPayment, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerPaymentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}