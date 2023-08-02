using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AccountAdjustmentGetListSpec : Specification<AccountAdjustment>
    {
        public AccountAdjustmentGetListSpec()
        {
            Query.Where(accountAdjustment => accountAdjustment.IsDeleted == false)
                .AsNoTracking();
        }
    }
}