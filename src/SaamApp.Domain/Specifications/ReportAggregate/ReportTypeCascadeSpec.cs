using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetReportWithReportTypeKeySpec : Specification<Report>
    {
        public GetReportWithReportTypeKeySpec(Guid reportTypeId)
        {
            Guard.Against.NullOrEmpty(reportTypeId, nameof(reportTypeId));
            Query.Where(r => r.ReportTypeId == reportTypeId).AsNoTracking();
        }
    }
}