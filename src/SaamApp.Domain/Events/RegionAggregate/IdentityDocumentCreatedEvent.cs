using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class IdentityDocumentCreatedEvent : BaseDomainEvent
    {
        public IdentityDocumentCreatedEvent(IdentityDocument identityDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "IdentityDocument";
            Content = JsonConvert.SerializeObject(identityDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "IdentityDocumentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}