using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class ProductCategoryDeletedEvent : BaseDomainEvent
    {
        public ProductCategoryDeletedEvent(ProductCategory productCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "ProductCategory";
            Content = JsonConvert.SerializeObject(productCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "ProductCategoryDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}