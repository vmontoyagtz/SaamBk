using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorApplicantUpdatedEvent : BaseDomainEvent
    {
        public AdvisorApplicantUpdatedEvent(AdvisorApplicant advisorApplicant, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorApplicant";
            Content = JsonConvert.SerializeObject(advisorApplicant, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorApplicantUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}