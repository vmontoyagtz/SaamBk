using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ReportGetListSpec : Specification<Report>
    {
        public ReportGetListSpec()
        {
            Query.Where(report => report.IsListReport == true)
                .OrderBy(report => report.ReportName)
                .AsNoTracking();
        }
    }
}