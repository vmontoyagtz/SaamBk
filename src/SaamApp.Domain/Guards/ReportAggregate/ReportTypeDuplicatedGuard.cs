using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class ReportTypeGuardExtensions
    {
        public static void DuplicateReportType(this IGuardClause guardClause,
            IEnumerable<ReportType> existingReportTypes, ReportType newReportType, string parameterName)
        {
            if (existingReportTypes.Any(a => a.ReportTypeId == newReportType.ReportTypeId))
            {
                throw new DuplicateReportTypeException("Cannot add duplicate reportType.", parameterName);
            }
        }
    }
}