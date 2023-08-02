using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AreaDeletedEvent : BaseDomainEvent
    {
        public AreaDeletedEvent(Area area, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Area";
            Content = JsonConvert.SerializeObject(area, JsonSerializerSettingsSingleton.Instance);
            EventType = "AreaDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}