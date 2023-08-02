using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AddressTypeDeletedEvent : BaseDomainEvent
    {
        public AddressTypeDeletedEvent(AddressType addressType, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AddressType";
            Content = JsonConvert.SerializeObject(addressType, JsonSerializerSettingsSingleton.Instance);
            EventType = "AddressTypeDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}