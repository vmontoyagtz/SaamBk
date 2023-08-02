using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AppConfigParamCreatedEvent : BaseDomainEvent
    {
        public AppConfigParamCreatedEvent(AppConfigParam appConfigParam, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AppConfigParam";
            Content = JsonConvert.SerializeObject(appConfigParam, JsonSerializerSettingsSingleton.Instance);
            EventType = "AppConfigParamCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}