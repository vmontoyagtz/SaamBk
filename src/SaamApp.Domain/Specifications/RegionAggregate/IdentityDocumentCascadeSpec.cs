using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorIdentityDocumentWithIdentityDocumentKeySpec : Specification<AdvisorIdentityDocument>
    {
        public GetAdvisorIdentityDocumentWithIdentityDocumentKeySpec(Guid identityDocumentId)
        {
            Guard.Against.NullOrEmpty(identityDocumentId, nameof(identityDocumentId));
            Query.Where(aid => aid.IdentityDocumentId == identityDocumentId).AsNoTracking();
        }
    }
}