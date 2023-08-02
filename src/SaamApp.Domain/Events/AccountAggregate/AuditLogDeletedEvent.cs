using System;
using Newtonsoft.Json;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;

namespace SaamApp.Domain.Events
{
    public class AuditLogDeletedEvent : BaseDomainEvent
    {
        public AuditLogDeletedEvent(AuditLog auditLog, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "AuditLog";
            Content = JsonConvert.SerializeObject(auditLog, JsonSerializerSettingsSingleton.Instance);
            EventType = "AuditLogDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}