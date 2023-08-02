using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorApplicantCreatedEvent : BaseDomainEvent
    {
        public AdvisorApplicantCreatedEvent(AdvisorApplicant advisorApplicant, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorApplicant";
            Content = JsonConvert.SerializeObject(advisorApplicant, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorApplicantCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}