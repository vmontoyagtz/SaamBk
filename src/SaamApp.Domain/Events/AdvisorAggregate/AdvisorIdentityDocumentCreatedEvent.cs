using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorIdentityDocumentCreatedEvent : BaseDomainEvent
    {
        public AdvisorIdentityDocumentCreatedEvent(AdvisorIdentityDocument advisorIdentityDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorIdentityDocument";
            Content = JsonConvert.SerializeObject(advisorIdentityDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorIdentityDocumentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}