using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod
{
    public class ListFinancialAccountingPeriodResponse : BaseResponse
    {
        public ListFinancialAccountingPeriodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListFinancialAccountingPeriodResponse()
        {
        }

        public List<FinancialAccountingPeriodDto> FinancialAccountingPeriods { get; set; } = new();

        public int Count { get; set; }
    }
}