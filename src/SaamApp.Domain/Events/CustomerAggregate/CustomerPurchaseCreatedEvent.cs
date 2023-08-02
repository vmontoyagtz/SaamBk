using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerPurchaseCreatedEvent : BaseDomainEvent
    {
        public CustomerPurchaseCreatedEvent(CustomerPurchase customerPurchase, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerPurchase";
            Content = JsonConvert.SerializeObject(customerPurchase, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerPurchaseCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}