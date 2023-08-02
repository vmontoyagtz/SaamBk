using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class CustomerPhoneNumberDeletedEvent : BaseDomainEvent
    {
        public CustomerPhoneNumberDeletedEvent(CustomerPhoneNumber customerPhoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "CustomerPhoneNumber";
            Content = JsonConvert.SerializeObject(customerPhoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerPhoneNumberDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}