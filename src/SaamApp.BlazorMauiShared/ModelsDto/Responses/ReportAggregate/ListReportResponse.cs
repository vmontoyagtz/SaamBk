using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class ListReportResponse : BaseResponse
    {
        public ListReportResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListReportResponse()
        {
        }

        public List<ReportDto> Reports { get; set; } = new();

        public int Count { get; set; }
    }
}