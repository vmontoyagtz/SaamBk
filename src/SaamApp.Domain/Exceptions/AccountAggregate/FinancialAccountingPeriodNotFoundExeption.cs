using System;

namespace SaamApp.Domain.Exceptions
{
    public class FinancialAccountingPeriodNotFoundException : Exception
    {
        public FinancialAccountingPeriodNotFoundException(string message) : base(message)
        {
        }

        public FinancialAccountingPeriodNotFoundException(Guid financialAccountingPeriodId) : base(
            $"No financialAccountingPeriod with id {financialAccountingPeriodId} found.")
        {
        }
    }
}