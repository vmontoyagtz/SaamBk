using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateTypeCreatedEvent : BaseDomainEvent
    {
        public TemplateTypeCreatedEvent(TemplateType templateType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TemplateType";
            Content = JsonConvert.SerializeObject(templateType, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateTypeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}