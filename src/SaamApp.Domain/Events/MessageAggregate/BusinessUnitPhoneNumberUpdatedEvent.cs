using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitPhoneNumberUpdatedEvent : BaseDomainEvent
    {
        public BusinessUnitPhoneNumberUpdatedEvent(BusinessUnitPhoneNumber businessUnitPhoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitPhoneNumber";
            Content = JsonConvert.SerializeObject(businessUnitPhoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitPhoneNumberUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}