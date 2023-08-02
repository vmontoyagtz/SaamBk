using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerAccountDeletedEvent : BaseDomainEvent
    {
        public CustomerAccountDeletedEvent(CustomerAccount customerAccount, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerAccount";
            Content = JsonConvert.SerializeObject(customerAccount, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerAccountDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}