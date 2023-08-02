using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AddressCreatedEvent : BaseDomainEvent
    {
        public AddressCreatedEvent(Address address, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Address";
            Content = JsonConvert.SerializeObject(address, JsonSerializerSettingsSingleton.Instance);
            EventType = "AddressCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}