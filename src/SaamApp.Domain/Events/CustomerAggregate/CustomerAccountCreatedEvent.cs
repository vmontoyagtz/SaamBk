using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerAccountCreatedEvent : BaseDomainEvent
    {
        public CustomerAccountCreatedEvent(CustomerAccount customerAccount, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerAccount";
            Content = JsonConvert.SerializeObject(customerAccount, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerAccountCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}