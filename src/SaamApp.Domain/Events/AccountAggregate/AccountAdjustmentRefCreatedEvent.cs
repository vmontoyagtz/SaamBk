using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountAdjustmentRefCreatedEvent : BaseDomainEvent
    {
        public AccountAdjustmentRefCreatedEvent(AccountAdjustmentRef accountAdjustmentRef, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AccountAdjustmentRef";
            Content = JsonConvert.SerializeObject(accountAdjustmentRef, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountAdjustmentRefCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}