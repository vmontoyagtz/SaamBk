using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerCreatedEvent : BaseDomainEvent
    {
        public CustomerCreatedEvent(Customer customer, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Customer";
            Content = JsonConvert.SerializeObject(customer, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}