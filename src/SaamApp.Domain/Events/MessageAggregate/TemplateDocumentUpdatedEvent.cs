using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateDocumentUpdatedEvent : BaseDomainEvent
    {
        public TemplateDocumentUpdatedEvent(TemplateDocument templateDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TemplateDocument";
            Content = JsonConvert.SerializeObject(templateDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateDocumentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}