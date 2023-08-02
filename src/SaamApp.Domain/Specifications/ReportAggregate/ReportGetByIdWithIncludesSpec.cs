using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ReportByIdWithIncludesSpec : Specification<Report>, ISingleResultSpecification
    {
        public ReportByIdWithIncludesSpec(Guid reportId)
        {
            Guard.Against.NullOrEmpty(reportId, nameof(reportId));
            Query.Where(report => report.ReportId == reportId)
                .OrderBy(report => report.ReportName)
                .Include(a => a.ReportType)
                .AsNoTracking();
        }
    }
}