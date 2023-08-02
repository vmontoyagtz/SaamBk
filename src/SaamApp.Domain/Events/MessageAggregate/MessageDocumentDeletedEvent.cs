using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class MessageDocumentDeletedEvent : BaseDomainEvent
    {
        public MessageDocumentDeletedEvent(MessageDocument messageDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "MessageDocument";
            Content = JsonConvert.SerializeObject(messageDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "MessageDocumentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}