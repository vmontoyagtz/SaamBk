using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class UpdateReportTypeResponse : BaseResponse
    {
        public UpdateReportTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateReportTypeResponse()
        {
        }

        public ReportTypeDto ReportType { get; set; } = new();
    }
}