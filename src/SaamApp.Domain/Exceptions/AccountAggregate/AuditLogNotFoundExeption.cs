using System;

namespace SaamApp.Domain.Exceptions
{
    public class AuditLogNotFoundException : Exception
    {
        public AuditLogNotFoundException(string message) : base(message)
        {
        }

        public AuditLogNotFoundException(Guid auditLogId) : base($"No auditLog with id {auditLogId} found.")
        {
        }
    }
}