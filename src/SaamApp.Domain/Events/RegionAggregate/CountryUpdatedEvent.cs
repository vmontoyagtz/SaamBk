using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CountryUpdatedEvent : BaseDomainEvent
    {
        public CountryUpdatedEvent(Country country, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Country";
            Content = JsonConvert.SerializeObject(country, JsonSerializerSettingsSingleton.Instance);
            EventType = "CountryUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}