using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AccountAdjustmentRefGetListSpec : Specification<AccountAdjustmentRef>
    {
        public AccountAdjustmentRefGetListSpec()
        {
            Query.OrderBy(accountAdjustmentRef => accountAdjustmentRef.AccountAdjustmentRefId)
                .AsNoTracking();
        }
    }
}