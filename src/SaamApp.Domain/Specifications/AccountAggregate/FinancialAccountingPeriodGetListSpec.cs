using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class FinancialAccountingPeriodGetListSpec : Specification<FinancialAccountingPeriod>
    {
        public FinancialAccountingPeriodGetListSpec()
        {
            Query.Where(financialAccountingPeriod => financialAccountingPeriod.IsStatementsJobRunning == true)
                .AsNoTracking();
        }
    }
}