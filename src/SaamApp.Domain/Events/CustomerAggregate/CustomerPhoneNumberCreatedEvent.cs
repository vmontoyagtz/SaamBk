using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerPhoneNumberCreatedEvent : BaseDomainEvent
    {
        public CustomerPhoneNumberCreatedEvent(CustomerPhoneNumber customerPhoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerPhoneNumber";
            Content = JsonConvert.SerializeObject(customerPhoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerPhoneNumberCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}