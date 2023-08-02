using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmailAddressTypeUpdatedEvent : BaseDomainEvent
    {
        public EmailAddressTypeUpdatedEvent(EmailAddressType emailAddressType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmailAddressType";
            Content = JsonConvert.SerializeObject(emailAddressType, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmailAddressTypeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}