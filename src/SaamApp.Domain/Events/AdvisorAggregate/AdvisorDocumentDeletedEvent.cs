using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AdvisorDocumentDeletedEvent : BaseDomainEvent
    {
        public AdvisorDocumentDeletedEvent(AdvisorDocument advisorDocument, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AdvisorDocument";
            Content = JsonConvert.SerializeObject(advisorDocument, JsonSerializerSettingsSingleton.Instance);
            EventType = "AdvisorDocumentDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}