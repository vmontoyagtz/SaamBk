using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AuditLogCreatedEvent : BaseDomainEvent
    {
        public AuditLogCreatedEvent(AuditLog auditLog, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AuditLog";
            Content = JsonConvert.SerializeObject(auditLog, JsonSerializerSettingsSingleton.Instance);
            EventType = "AuditLogCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}