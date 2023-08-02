using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorIdentityDocumentUpdatedEvent : BaseDomainEvent
    {
        public AdvisorIdentityDocumentUpdatedEvent(AdvisorIdentityDocument advisorIdentityDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorIdentityDocument";
            Content = JsonConvert.SerializeObject(advisorIdentityDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorIdentityDocumentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}