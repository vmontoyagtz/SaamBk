using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BankUpdatedEvent : BaseDomainEvent
    {
        public BankUpdatedEvent(Bank bank, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Bank";
            Content = JsonConvert.SerializeObject(bank, JsonSerializerSettingsSingleton.Instance);
            EventType = "BankUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}