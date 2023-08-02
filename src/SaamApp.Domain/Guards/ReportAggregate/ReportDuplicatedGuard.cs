using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class ReportGuardExtensions
    {
        public static void DuplicateReport(this IGuardClause guardClause, IEnumerable<Report> existingReports,
            Report newReport, string parameterName)
        {
            if (existingReports.Any(a => a.ReportId == newReport.ReportId))
            {
                throw new DuplicateReportException("Cannot add duplicate report.", parameterName);
            }
        }
    }
}