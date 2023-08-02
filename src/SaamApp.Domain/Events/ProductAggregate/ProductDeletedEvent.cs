using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ProductDeletedEvent : BaseDomainEvent
    {
        public ProductDeletedEvent(Product product, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Product";
            Content = JsonConvert.SerializeObject(product, JsonSerializerSettingsSingleton.Instance);
            EventType = "ProductDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}