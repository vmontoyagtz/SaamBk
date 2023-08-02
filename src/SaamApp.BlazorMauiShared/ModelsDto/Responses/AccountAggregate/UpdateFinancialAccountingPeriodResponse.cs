using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class UpdateFinancialAccountingPeriodResponse : BaseResponse
    {
        public UpdateFinancialAccountingPeriodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateFinancialAccountingPeriodResponse()
        {
        }

        public FinancialAccountingPeriodDto FinancialAccountingPeriod { get; set; } = new();
    }
}