using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class EmailAddressDeletedEvent : BaseDomainEvent
    {
        public EmailAddressDeletedEvent(EmailAddress emailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "EmailAddress";
            Content = JsonConvert.SerializeObject(emailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "EmailAddressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}