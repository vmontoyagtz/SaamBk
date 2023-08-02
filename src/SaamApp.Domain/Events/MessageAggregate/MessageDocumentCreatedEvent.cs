using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class MessageDocumentCreatedEvent : BaseDomainEvent
    {
        public MessageDocumentCreatedEvent(MessageDocument messageDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "MessageDocument";
            Content = JsonConvert.SerializeObject(messageDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "MessageDocumentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}