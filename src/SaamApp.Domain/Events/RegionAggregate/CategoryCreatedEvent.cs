using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CategoryCreatedEvent : BaseDomainEvent
    {
        public CategoryCreatedEvent(Category category, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Category";
            Content = JsonConvert.SerializeObject(category, JsonSerializerSettingsSingleton.Instance);
            EventType = "CategoryCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}