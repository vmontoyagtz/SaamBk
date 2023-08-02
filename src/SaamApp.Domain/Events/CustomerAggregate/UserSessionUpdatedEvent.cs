using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class UserSessionUpdatedEvent : BaseDomainEvent
    {
        public UserSessionUpdatedEvent(UserSession userSession, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "UserSession";
            Content = JsonConvert.SerializeObject(userSession, JsonSerializerSettingsSingleton.Instance);
            EventType = "UserSessionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}