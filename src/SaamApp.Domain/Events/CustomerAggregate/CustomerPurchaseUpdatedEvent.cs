using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerPurchaseUpdatedEvent : BaseDomainEvent
    {
        public CustomerPurchaseUpdatedEvent(CustomerPurchase customerPurchase, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerPurchase";
            Content = JsonConvert.SerializeObject(customerPurchase, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerPurchaseUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}