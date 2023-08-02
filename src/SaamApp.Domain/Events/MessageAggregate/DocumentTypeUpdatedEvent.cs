using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DocumentTypeUpdatedEvent : BaseDomainEvent
    {
        public DocumentTypeUpdatedEvent(DocumentType documentType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "DocumentType";
            Content = JsonConvert.SerializeObject(documentType, JsonSerializerSettingsSingleton.Instance);
            EventType = "DocumentTypeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}