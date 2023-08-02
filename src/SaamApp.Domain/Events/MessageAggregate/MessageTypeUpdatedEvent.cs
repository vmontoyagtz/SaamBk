using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class MessageTypeUpdatedEvent : BaseDomainEvent
    {
        public MessageTypeUpdatedEvent(MessageType messageType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "MessageType";
            Content = JsonConvert.SerializeObject(messageType, JsonSerializerSettingsSingleton.Instance);
            EventType = "MessageTypeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}