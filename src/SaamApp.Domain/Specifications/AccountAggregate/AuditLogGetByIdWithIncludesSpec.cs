using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AuditLogByIdWithIncludesSpec : Specification<AuditLog>, ISingleResultSpecification
    {
        public AuditLogByIdWithIncludesSpec(Guid auditLogId)
        {
            Guard.Against.NullOrEmpty(auditLogId, nameof(auditLogId));
            Query.Where(auditLog => auditLog.AuditLogId == auditLogId)
                .AsNoTracking();
        }
    }
}