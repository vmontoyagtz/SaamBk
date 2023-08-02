using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class CreateReportTypeResponse : BaseResponse
    {
        public CreateReportTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateReportTypeResponse()
        {
        }

        public ReportTypeDto ReportType { get; set; } = new();
    }
}