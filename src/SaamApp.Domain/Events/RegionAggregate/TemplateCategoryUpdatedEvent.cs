using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateCategoryUpdatedEvent : BaseDomainEvent
    {
        public TemplateCategoryUpdatedEvent(TemplateCategory templateCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TemplateCategory";
            Content = JsonConvert.SerializeObject(templateCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateCategoryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}