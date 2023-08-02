using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerAddressCreatedEvent : BaseDomainEvent
    {
        public CustomerAddressCreatedEvent(CustomerAddress customerAddress, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerAddress";
            Content = JsonConvert.SerializeObject(customerAddress, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerAddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}