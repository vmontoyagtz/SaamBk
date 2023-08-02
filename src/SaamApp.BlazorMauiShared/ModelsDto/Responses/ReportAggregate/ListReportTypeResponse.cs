using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class ListReportTypeResponse : BaseResponse
    {
        public ListReportTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListReportTypeResponse()
        {
        }

        public List<ReportTypeDto> ReportTypes { get; set; } = new();

        public int Count { get; set; }
    }
}