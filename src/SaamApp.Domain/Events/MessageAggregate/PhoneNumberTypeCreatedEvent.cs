using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PhoneNumberTypeCreatedEvent : BaseDomainEvent
    {
        public PhoneNumberTypeCreatedEvent(PhoneNumberType phoneNumberType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PhoneNumberType";
            Content = JsonConvert.SerializeObject(phoneNumberType, JsonSerializerSettingsSingleton.Instance);
            EventType = "PhoneNumberTypeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}