using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ProductCategoryUpdatedEvent : BaseDomainEvent
    {
        public ProductCategoryUpdatedEvent(ProductCategory productCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ProductCategory";
            Content = JsonConvert.SerializeObject(productCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "ProductCategoryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}