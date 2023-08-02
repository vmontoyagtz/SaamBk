using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AddressTypeCreatedEvent : BaseDomainEvent
    {
        public AddressTypeCreatedEvent(AddressType addressType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AddressType";
            Content = JsonConvert.SerializeObject(addressType, JsonSerializerSettingsSingleton.Instance);
            EventType = "AddressTypeCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}