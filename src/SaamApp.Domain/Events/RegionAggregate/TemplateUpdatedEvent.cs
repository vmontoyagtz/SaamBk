using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateUpdatedEvent : BaseDomainEvent
    {
        public TemplateUpdatedEvent(Template template, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Template";
            Content = JsonConvert.SerializeObject(template, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}