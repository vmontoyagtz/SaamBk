using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AuditLogUpdatedEvent : BaseDomainEvent
    {
        public AuditLogUpdatedEvent(AuditLog auditLog, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AuditLog";
            Content = JsonConvert.SerializeObject(auditLog, JsonSerializerSettingsSingleton.Instance);
            EventType = "AuditLogUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}