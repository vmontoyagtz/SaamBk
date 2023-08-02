using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ReportTypeGetListSpec : Specification<ReportType>
    {
        public ReportTypeGetListSpec()
        {
            Query.OrderBy(reportType => reportType.ReportTypeId)
                .AsNoTracking();
        }
    }
}