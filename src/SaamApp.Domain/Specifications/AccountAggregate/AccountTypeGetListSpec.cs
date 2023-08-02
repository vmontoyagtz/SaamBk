using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AccountTypeGetListSpec : Specification<AccountType>
    {
        public AccountTypeGetListSpec()
        {
            Query.OrderBy(accountType => accountType.AccountTypeId)
                .AsNoTracking();
        }
    }
}