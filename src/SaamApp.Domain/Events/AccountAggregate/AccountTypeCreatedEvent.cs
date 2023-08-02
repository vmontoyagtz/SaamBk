using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountTypeCreatedEvent : BaseDomainEvent
    {
        public AccountTypeCreatedEvent(AccountType accountType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AccountType";
            Content = JsonConvert.SerializeObject(accountType, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountTypeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}