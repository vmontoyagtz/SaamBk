using System;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class GetByIdReportRequest : BaseRequest
    {
        public Guid ReportId { get; set; }
    }
}