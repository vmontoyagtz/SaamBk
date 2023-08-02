using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PhoneNumberDeletedEvent : BaseDomainEvent
    {
        public PhoneNumberDeletedEvent(PhoneNumber phoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PhoneNumber";
            Content = JsonConvert.SerializeObject(phoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "PhoneNumberDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}