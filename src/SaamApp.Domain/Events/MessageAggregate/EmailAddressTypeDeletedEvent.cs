using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmailAddressTypeDeletedEvent : BaseDomainEvent
    {
        public EmailAddressTypeDeletedEvent(EmailAddressType emailAddressType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmailAddressType";
            Content = JsonConvert.SerializeObject(emailAddressType, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmailAddressTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}