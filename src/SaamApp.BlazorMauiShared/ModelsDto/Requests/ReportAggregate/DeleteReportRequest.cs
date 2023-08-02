using System;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class DeleteReportRequest : BaseRequest
    {
        public Guid ReportId { get; set; }
    }
}