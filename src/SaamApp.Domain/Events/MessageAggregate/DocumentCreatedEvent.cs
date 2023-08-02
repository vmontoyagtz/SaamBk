using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DocumentCreatedEvent : BaseDomainEvent
    {
        public DocumentCreatedEvent(Document document, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Document";
            Content = JsonConvert.SerializeObject(document, JsonSerializerSettingsSingleton.Instance);
            EventType = "DocumentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}