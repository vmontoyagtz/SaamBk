using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountAdjustmentCreatedEvent : BaseDomainEvent
    {
        public AccountAdjustmentCreatedEvent(AccountAdjustment accountAdjustment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AccountAdjustment";
            Content = JsonConvert.SerializeObject(accountAdjustment, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountAdjustmentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}