using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorIdentityDocumentDeletedEvent : BaseDomainEvent
    {
        public AdvisorIdentityDocumentDeletedEvent(AdvisorIdentityDocument advisorIdentityDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorIdentityDocument";
            Content = JsonConvert.SerializeObject(advisorIdentityDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorIdentityDocumentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}