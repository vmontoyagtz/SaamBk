using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class GetByIdReportTypeResponse : BaseResponse
    {
        public GetByIdReportTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdReportTypeResponse()
        {
        }

        public ReportTypeDto ReportType { get; set; } = new();
    }
}