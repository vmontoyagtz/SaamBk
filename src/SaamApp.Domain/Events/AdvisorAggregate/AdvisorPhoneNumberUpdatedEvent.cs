using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorPhoneNumberUpdatedEvent : BaseDomainEvent
    {
        public AdvisorPhoneNumberUpdatedEvent(AdvisorPhoneNumber advisorPhoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorPhoneNumber";
            Content = JsonConvert.SerializeObject(advisorPhoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorPhoneNumberUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}