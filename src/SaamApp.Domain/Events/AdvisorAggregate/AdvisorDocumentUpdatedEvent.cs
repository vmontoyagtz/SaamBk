using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorDocumentUpdatedEvent : BaseDomainEvent
    {
        public AdvisorDocumentUpdatedEvent(AdvisorDocument advisorDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorDocument";
            Content = JsonConvert.SerializeObject(advisorDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorDocumentUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}