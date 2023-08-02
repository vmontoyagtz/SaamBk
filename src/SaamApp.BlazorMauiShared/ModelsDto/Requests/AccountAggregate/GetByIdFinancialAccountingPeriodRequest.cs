using System;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class GetByIdFinancialAccountingPeriodRequest : BaseRequest
    {
        public Guid FinancialAccountingPeriodId { get; set; }
    }
}