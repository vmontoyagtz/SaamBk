using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerEmailAddressCreatedEvent : BaseDomainEvent
    {
        public CustomerEmailAddressCreatedEvent(CustomerEmailAddress customerEmailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerEmailAddress";
            Content = JsonConvert.SerializeObject(customerEmailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerEmailAddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}