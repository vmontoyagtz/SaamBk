using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CategoryDeletedEvent : BaseDomainEvent
    {
        public CategoryDeletedEvent(Category category, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Category";
            Content = JsonConvert.SerializeObject(category, JsonSerializerSettingsSingleton.Instance);
            EventType = "CategoryDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}