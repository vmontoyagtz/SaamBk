using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerPurchaseDeletedEvent : BaseDomainEvent
    {
        public CustomerPurchaseDeletedEvent(CustomerPurchase customerPurchase, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerPurchase";
            Content = JsonConvert.SerializeObject(customerPurchase, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerPurchaseDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}