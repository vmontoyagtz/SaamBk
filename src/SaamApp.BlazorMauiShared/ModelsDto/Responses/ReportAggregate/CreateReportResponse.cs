using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class CreateReportResponse : BaseResponse
    {
        public CreateReportResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateReportResponse()
        {
        }

        public ReportDto Report { get; set; } = new();
    }
}