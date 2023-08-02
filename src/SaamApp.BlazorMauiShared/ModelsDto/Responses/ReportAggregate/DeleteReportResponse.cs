using System;

namespace SaamApp.BlazorMauiShared.Models.Report
{
    public class DeleteReportResponse : BaseResponse
    {
        public DeleteReportResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteReportResponse()
        {
        }
    }
}