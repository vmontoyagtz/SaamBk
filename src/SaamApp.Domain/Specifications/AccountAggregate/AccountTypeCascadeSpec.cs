using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAccountWithAccountTypeKeySpec : Specification<Account>
    {
        public GetAccountWithAccountTypeKeySpec(Guid accountTypeId)
        {
            Guard.Against.NullOrEmpty(accountTypeId, nameof(accountTypeId));
            Query.Where(a => a.AccountTypeId == accountTypeId).AsNoTracking();
        }
    }
}