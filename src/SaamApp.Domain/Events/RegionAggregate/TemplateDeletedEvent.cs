using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateDeletedEvent : BaseDomainEvent
    {
        public TemplateDeletedEvent(Template template, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Template";
            Content = JsonConvert.SerializeObject(template, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}