using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AccountStateTypeGetListSpec : Specification<AccountStateType>
    {
        public AccountStateTypeGetListSpec()
        {
            Query.OrderBy(accountStateType => accountStateType.AccountStateTypeId)
                .AsNoTracking();
        }
    }
}