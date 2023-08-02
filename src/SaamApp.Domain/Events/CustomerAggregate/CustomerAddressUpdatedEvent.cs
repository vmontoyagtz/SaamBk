using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerAddressUpdatedEvent : BaseDomainEvent
    {
        public CustomerAddressUpdatedEvent(CustomerAddress customerAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerAddress";
            Content = JsonConvert.SerializeObject(customerAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerAddressUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}