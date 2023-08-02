using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BankCreatedEvent : BaseDomainEvent
    {
        public BankCreatedEvent(Bank bank, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Bank";
            Content = JsonConvert.SerializeObject(bank, JsonSerializerSettingsSingleton.Instance);
            EventType = "BankCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}