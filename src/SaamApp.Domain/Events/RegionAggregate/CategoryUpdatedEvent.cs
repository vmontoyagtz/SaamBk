using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CategoryUpdatedEvent : BaseDomainEvent
    {
        public CategoryUpdatedEvent(Category category, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Category";
            Content = JsonConvert.SerializeObject(category, JsonSerializerSettingsSingleton.Instance);
            EventType = "CategoryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}