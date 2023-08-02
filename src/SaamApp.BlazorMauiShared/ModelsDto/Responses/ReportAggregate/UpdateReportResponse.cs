using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class UpdateReportResponse : BaseResponse
    {
        public UpdateReportResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateReportResponse()
        {
        }

        public ReportDto Report { get; set; } = new();
    }
}