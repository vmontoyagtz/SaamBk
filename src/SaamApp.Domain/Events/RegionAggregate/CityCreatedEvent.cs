using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CityCreatedEvent : BaseDomainEvent
    {
        public CityCreatedEvent(City city, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "City";
            Content = JsonConvert.SerializeObject(city, JsonSerializerSettingsSingleton.Instance);
            EventType = "CityCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}