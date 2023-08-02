using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AccountAdjustmentDeletedEvent : BaseDomainEvent
    {
        public AccountAdjustmentDeletedEvent(AccountAdjustment accountAdjustment, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AccountAdjustment";
            Content = JsonConvert.SerializeObject(accountAdjustment, JsonSerializerSettingsSingleton.Instance);
            EventType = "AccountAdjustmentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}