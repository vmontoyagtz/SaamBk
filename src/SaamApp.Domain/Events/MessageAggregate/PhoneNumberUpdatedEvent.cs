using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PhoneNumberUpdatedEvent : BaseDomainEvent
    {
        public PhoneNumberUpdatedEvent(PhoneNumber phoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PhoneNumber";
            Content = JsonConvert.SerializeObject(phoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "PhoneNumberUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}