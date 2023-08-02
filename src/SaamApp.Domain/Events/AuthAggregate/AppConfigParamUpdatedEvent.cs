using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AppConfigParamUpdatedEvent : BaseDomainEvent
    {
        public AppConfigParamUpdatedEvent(AppConfigParam appConfigParam, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AppConfigParam";
            Content = JsonConvert.SerializeObject(appConfigParam, JsonSerializerSettingsSingleton.Instance);
            EventType = "AppConfigParamUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}