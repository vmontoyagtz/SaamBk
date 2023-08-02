using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AreaUpdatedEvent : BaseDomainEvent
    {
        public AreaUpdatedEvent(Area area, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Area";
            Content = JsonConvert.SerializeObject(area, JsonSerializerSettingsSingleton.Instance);
            EventType = "AreaUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}