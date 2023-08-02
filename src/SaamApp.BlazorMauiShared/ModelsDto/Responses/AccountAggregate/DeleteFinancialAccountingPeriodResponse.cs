using System;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class DeleteFinancialAccountingPeriodResponse : BaseResponse
    {
        public DeleteFinancialAccountingPeriodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteFinancialAccountingPeriodResponse()
        {
        }
    }
}