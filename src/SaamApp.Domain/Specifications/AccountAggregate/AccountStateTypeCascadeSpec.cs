using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAccountWithAccountStateTypeKeySpec : Specification<Account>
    {
        public GetAccountWithAccountStateTypeKeySpec(Guid accountStateTypeId)
        {
            Guard.Against.NullOrEmpty(accountStateTypeId, nameof(accountStateTypeId));
            Query.Where(a => a.AccountStateTypeId == accountStateTypeId).AsNoTracking();
        }
    }
}