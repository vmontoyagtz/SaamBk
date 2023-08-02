using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountUpdatedEvent : BaseDomainEvent
    {
        public AccountUpdatedEvent(Account account, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Account";
            Content = JsonConvert.SerializeObject(account, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}