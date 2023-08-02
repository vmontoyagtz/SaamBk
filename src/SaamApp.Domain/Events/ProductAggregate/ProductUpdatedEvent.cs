using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ProductUpdatedEvent : BaseDomainEvent
    {
        public ProductUpdatedEvent(Product product, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Product";
            Content = JsonConvert.SerializeObject(product, JsonSerializerSettingsSingleton.Instance);
            EventType = "ProductUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}