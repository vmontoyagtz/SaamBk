using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorPhoneNumberDeletedEvent : BaseDomainEvent
    {
        public AdvisorPhoneNumberDeletedEvent(AdvisorPhoneNumber advisorPhoneNumber, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorPhoneNumber";
            Content = JsonConvert.SerializeObject(advisorPhoneNumber, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorPhoneNumberDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}