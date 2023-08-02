using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BankDeletedEvent : BaseDomainEvent
    {
        public BankDeletedEvent(Bank bank, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Bank";
            Content = JsonConvert.SerializeObject(bank, JsonSerializerSettingsSingleton.Instance);
            EventType = "BankDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}