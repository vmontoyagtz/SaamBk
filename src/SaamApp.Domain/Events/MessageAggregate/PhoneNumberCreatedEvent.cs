using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PhoneNumberCreatedEvent : BaseDomainEvent
    {
        public PhoneNumberCreatedEvent(PhoneNumber phoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PhoneNumber";
            Content = JsonConvert.SerializeObject(phoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "PhoneNumberCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}