using System;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class CreateReportTypeRequest : BaseRequest
    {
        public string ReportTypeName { get; set; }
        public string? ReportTypeDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}