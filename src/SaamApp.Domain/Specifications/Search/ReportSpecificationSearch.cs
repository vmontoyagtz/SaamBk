using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications.Search
{
    public class ReportSearchByReportName : Specification<Report>
    {
        public ReportSearchByReportName(ReportFilterModel filter)
        {
            if (!string.IsNullOrEmpty(filter.ReportName))
            {
                Query
                    .Search(x => x.ReportName, "%" + filter.ReportName + "%");
            }
        }
    }
}