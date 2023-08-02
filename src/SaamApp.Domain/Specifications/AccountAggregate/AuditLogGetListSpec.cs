using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AuditLogGetListSpec : Specification<AuditLog>
    {
        public AuditLogGetListSpec()
        {
            Query.OrderBy(auditLog => auditLog.AuditLogId)
                .AsNoTracking();
        }
    }
}