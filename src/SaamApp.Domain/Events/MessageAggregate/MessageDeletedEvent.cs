using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class MessageDeletedEvent : BaseDomainEvent
    {
        public MessageDeletedEvent(Message message, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Message";
            Content = JsonConvert.SerializeObject(message, JsonSerializerSettingsSingleton.Instance);
            EventType = "MessageDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}