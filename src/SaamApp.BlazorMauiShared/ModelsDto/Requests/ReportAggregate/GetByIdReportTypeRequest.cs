using System;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class GetByIdReportTypeRequest : BaseRequest
    {
        public Guid ReportTypeId { get; set; }
    }
}