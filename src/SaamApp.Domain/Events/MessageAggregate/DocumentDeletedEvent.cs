using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DocumentDeletedEvent : BaseDomainEvent
    {
        public DocumentDeletedEvent(Document document, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Document";
            Content = JsonConvert.SerializeObject(document, JsonSerializerSettingsSingleton.Instance);
            EventType = "DocumentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}