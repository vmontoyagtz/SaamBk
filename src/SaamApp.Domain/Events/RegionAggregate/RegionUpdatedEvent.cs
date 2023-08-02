using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class RegionUpdatedEvent : BaseDomainEvent
    {
        public RegionUpdatedEvent(Region region, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Region";
            Content = JsonConvert.SerializeObject(region, JsonSerializerSettingsSingleton.Instance);
            EventType = "RegionUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}