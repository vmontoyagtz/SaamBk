using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class PhoneNumberTypeDeletedEvent : BaseDomainEvent
    {
        public PhoneNumberTypeDeletedEvent(PhoneNumberType phoneNumberType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "PhoneNumberType";
            Content = JsonConvert.SerializeObject(phoneNumberType, JsonSerializerSettingsSingleton.Instance);
            EventType = "PhoneNumberTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}