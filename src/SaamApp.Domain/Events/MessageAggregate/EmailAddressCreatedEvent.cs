using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmailAddressCreatedEvent : BaseDomainEvent
    {
        public EmailAddressCreatedEvent(EmailAddress emailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmailAddress";
            Content = JsonConvert.SerializeObject(emailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmailAddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}