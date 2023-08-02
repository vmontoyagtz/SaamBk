using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountStateTypeDeletedEvent : BaseDomainEvent
    {
        public AccountStateTypeDeletedEvent(AccountStateType accountStateType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AccountStateType";
            Content = JsonConvert.SerializeObject(accountStateType, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountStateTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}