using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AddressDeletedEvent : BaseDomainEvent
    {
        public AddressDeletedEvent(Address address, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Address";
            Content = JsonConvert.SerializeObject(address, JsonSerializerSettingsSingleton.Instance);
            EventType = "AddressDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}