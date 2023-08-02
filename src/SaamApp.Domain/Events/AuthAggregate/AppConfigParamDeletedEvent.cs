using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AppConfigParamDeletedEvent : BaseDomainEvent
    {
        public AppConfigParamDeletedEvent(AppConfigParam appConfigParam, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AppConfigParam";
            Content = JsonConvert.SerializeObject(appConfigParam, JsonSerializerSettingsSingleton.Instance);
            EventType = "AppConfigParamDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}