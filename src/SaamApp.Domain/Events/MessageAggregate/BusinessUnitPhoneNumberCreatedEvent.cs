using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class BusinessUnitPhoneNumberCreatedEvent : BaseDomainEvent
    {
        public BusinessUnitPhoneNumberCreatedEvent(BusinessUnitPhoneNumber businessUnitPhoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "BusinessUnitPhoneNumber";
            Content = JsonConvert.SerializeObject(businessUnitPhoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "BusinessUnitPhoneNumberCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}