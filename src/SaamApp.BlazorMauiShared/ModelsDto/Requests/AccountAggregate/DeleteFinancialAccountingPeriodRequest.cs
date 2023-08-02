using System;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class DeleteFinancialAccountingPeriodRequest : BaseRequest
    {
        public Guid FinancialAccountingPeriodId { get; set; }
    }
}