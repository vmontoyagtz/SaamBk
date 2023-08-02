using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerEmailAddressDeletedEvent : BaseDomainEvent
    {
        public CustomerEmailAddressDeletedEvent(CustomerEmailAddress customerEmailAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerEmailAddress";
            Content = JsonConvert.SerializeObject(customerEmailAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerEmailAddressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}