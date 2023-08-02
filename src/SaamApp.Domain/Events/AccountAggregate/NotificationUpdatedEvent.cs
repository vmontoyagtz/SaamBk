using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class NotificationUpdatedEvent : BaseDomainEvent
    {
        public NotificationUpdatedEvent(Notification notification, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Notification";
            Content = JsonConvert.SerializeObject(notification, JsonSerializerSettingsSingleton.Instance);
            EventType = "NotificationUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}