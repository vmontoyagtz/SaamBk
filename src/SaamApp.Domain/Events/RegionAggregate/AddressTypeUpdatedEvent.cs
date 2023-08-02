using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AddressTypeUpdatedEvent : BaseDomainEvent
    {
        public AddressTypeUpdatedEvent(AddressType addressType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AddressType";
            Content = JsonConvert.SerializeObject(addressType, JsonSerializerSettingsSingleton.Instance);
            EventType = "AddressTypeUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}