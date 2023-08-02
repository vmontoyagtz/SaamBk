using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateTypeDeletedEvent : BaseDomainEvent
    {
        public TemplateTypeDeletedEvent(TemplateType templateType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TemplateType";
            Content = JsonConvert.SerializeObject(templateType, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}