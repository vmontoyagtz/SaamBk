using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CityUpdatedEvent : BaseDomainEvent
    {
        public CityUpdatedEvent(City city, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "City";
            Content = JsonConvert.SerializeObject(city, JsonSerializerSettingsSingleton.Instance);
            EventType = "CityUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}