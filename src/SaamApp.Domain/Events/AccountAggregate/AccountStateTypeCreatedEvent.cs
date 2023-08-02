using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountStateTypeCreatedEvent : BaseDomainEvent
    {
        public AccountStateTypeCreatedEvent(AccountStateType accountStateType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AccountStateType";
            Content = JsonConvert.SerializeObject(accountStateType, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountStateTypeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}