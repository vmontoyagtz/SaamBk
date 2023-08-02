using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class TemplateDocumentCreatedEvent : BaseDomainEvent
    {
        public TemplateDocumentCreatedEvent(TemplateDocument templateDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "TemplateDocument";
            Content = JsonConvert.SerializeObject(templateDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "TemplateDocumentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}