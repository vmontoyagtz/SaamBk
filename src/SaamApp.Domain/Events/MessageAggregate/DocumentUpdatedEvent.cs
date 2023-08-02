using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DocumentUpdatedEvent : BaseDomainEvent
    {
        public DocumentUpdatedEvent(Document document, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Document";
            Content = JsonConvert.SerializeObject(document, JsonSerializerSettingsSingleton.Instance);
            EventType = "DocumentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}