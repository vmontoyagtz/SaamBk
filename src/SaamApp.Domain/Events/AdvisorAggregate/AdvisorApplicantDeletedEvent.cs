using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorApplicantDeletedEvent : BaseDomainEvent
    {
        public AdvisorApplicantDeletedEvent(AdvisorApplicant advisorApplicant, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorApplicant";
            Content = JsonConvert.SerializeObject(advisorApplicant, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorApplicantDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}