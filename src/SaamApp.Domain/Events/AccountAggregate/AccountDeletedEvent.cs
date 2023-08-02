using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountDeletedEvent : BaseDomainEvent
    {
        public AccountDeletedEvent(Account account, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Account";
            Content = JsonConvert.SerializeObject(account, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}