using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerUpdatedEvent : BaseDomainEvent
    {
        public CustomerUpdatedEvent(Customer customer, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Customer";
            Content = JsonConvert.SerializeObject(customer, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}