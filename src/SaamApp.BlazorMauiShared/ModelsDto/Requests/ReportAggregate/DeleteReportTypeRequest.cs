using System;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class DeleteReportTypeRequest : BaseRequest
    {
        public Guid ReportTypeId { get; set; }
    }
}