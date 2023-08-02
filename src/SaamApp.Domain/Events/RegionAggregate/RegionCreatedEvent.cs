using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class RegionCreatedEvent : BaseDomainEvent
    {
        public RegionCreatedEvent(Region region, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Region";
            Content = JsonConvert.SerializeObject(region, JsonSerializerSettingsSingleton.Instance);
            EventType = "RegionCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}