using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AccountGetListSpec : Specification<Account>
    {
        public AccountGetListSpec()
        {
            Query.Where(account => account.IsDeleted == false)
                .AsNoTracking();
        }
    }
}