using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class CreateFinancialAccountingPeriodResponse : BaseResponse
    {
        public CreateFinancialAccountingPeriodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateFinancialAccountingPeriodResponse()
        {
        }

        public FinancialAccountingPeriodDto FinancialAccountingPeriod { get; set; } = new();
    }
}