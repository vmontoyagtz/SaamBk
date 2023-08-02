using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class GetByIdFinancialAccountingPeriodResponse : BaseResponse
    {
        public GetByIdFinancialAccountingPeriodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdFinancialAccountingPeriodResponse()
        {
        }

        public FinancialAccountingPeriodDto FinancialAccountingPeriod { get; set; } = new();
    }
}