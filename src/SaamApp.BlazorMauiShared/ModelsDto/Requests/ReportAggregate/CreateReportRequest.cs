using System;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class CreateReportRequest : BaseRequest
    {
        public Guid ReportTypeId { get; set; }
        public Guid TenantId { get; set; }
        public string ReportName { get; set; }
        public string Module { get; set; }
        public bool? IsListReport { get; set; }
        public bool? IsFormReport { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public string? ReportJson { get; set; }
        public string? FrontEndMethodToCall { get; set; }
        public string? ApiMethodToCall { get; set; }
        public string? ParametersJson { get; set; }
    }
}