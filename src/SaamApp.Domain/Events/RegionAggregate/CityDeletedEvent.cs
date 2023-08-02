using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CityDeletedEvent : BaseDomainEvent
    {
        public CityDeletedEvent(City city, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "City";
            Content = JsonConvert.SerializeObject(city, JsonSerializerSettingsSingleton.Instance);
            EventType = "CityDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}