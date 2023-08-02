using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class NotificationDeletedEvent : BaseDomainEvent
    {
        public NotificationDeletedEvent(Notification notification, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Notification";
            Content = JsonConvert.SerializeObject(notification, JsonSerializerSettingsSingleton.Instance);
            EventType = "NotificationDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}