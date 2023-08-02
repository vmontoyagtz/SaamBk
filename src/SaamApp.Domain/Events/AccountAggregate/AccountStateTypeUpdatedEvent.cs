using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountStateTypeUpdatedEvent : BaseDomainEvent
    {
        public AccountStateTypeUpdatedEvent(AccountStateType accountStateType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AccountStateType";
            Content = JsonConvert.SerializeObject(accountStateType, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountStateTypeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}