using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorDocumentCreatedEvent : BaseDomainEvent
    {
        public AdvisorDocumentCreatedEvent(AdvisorDocument advisorDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorDocument";
            Content = JsonConvert.SerializeObject(advisorDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorDocumentCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}