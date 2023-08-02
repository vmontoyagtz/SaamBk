using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class DocumentTypeDeletedEvent : BaseDomainEvent
    {
        public DocumentTypeDeletedEvent(DocumentType documentType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "DocumentType";
            Content = JsonConvert.SerializeObject(documentType, JsonSerializerSettingsSingleton.Instance);
            EventType = "DocumentTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}