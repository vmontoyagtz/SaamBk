using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateCategoryCreatedEvent : BaseDomainEvent
    {
        public TemplateCategoryCreatedEvent(TemplateCategory templateCategory, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TemplateCategory";
            Content = JsonConvert.SerializeObject(templateCategory, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateCategoryCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}