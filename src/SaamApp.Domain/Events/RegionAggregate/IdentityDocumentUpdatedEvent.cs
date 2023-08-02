using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class IdentityDocumentUpdatedEvent : BaseDomainEvent
    {
        public IdentityDocumentUpdatedEvent(IdentityDocument identityDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "IdentityDocument";
            Content = JsonConvert.SerializeObject(identityDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "IdentityDocumentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}