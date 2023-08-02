using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class GetByIdReportResponse : BaseResponse
    {
        public GetByIdReportResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdReportResponse()
        {
        }

        public ReportDto Report { get; set; } = new();
    }
}