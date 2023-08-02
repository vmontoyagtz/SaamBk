using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BankAccountCreatedEvent : BaseDomainEvent
    {
        public BankAccountCreatedEvent(BankAccount bankAccount, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BankAccount";
            Content = JsonConvert.SerializeObject(bankAccount, JsonSerializerSettingsSingleton.Instance);
            EventType = "BankAccountCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}