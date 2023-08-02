using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateCreatedEvent : BaseDomainEvent
    {
        public TemplateCreatedEvent(Template template, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Template";
            Content = JsonConvert.SerializeObject(template, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}