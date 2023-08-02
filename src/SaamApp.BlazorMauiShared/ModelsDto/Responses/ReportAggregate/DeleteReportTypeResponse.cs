using System;

namespace SaamApp.BlazorMauiShared.Models.ReportType
{
    public class DeleteReportTypeResponse : BaseResponse
    {
        public DeleteReportTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteReportTypeResponse()
        {
        }
    }
}