using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAddressWithCountryKeySpec : Specification<Address>
    {
        public GetAddressWithCountryKeySpec(Guid countryId)
        {
            Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            Query.Where(a => a.CountryId == countryId).AsNoTracking();
        }
    }

    public class GetIdentityDocumentWithCountryKeySpec : Specification<IdentityDocument>
    {
        public GetIdentityDocumentWithCountryKeySpec(Guid countryId)
        {
            Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            Query.Where(id => id.CountryId == countryId).AsNoTracking();
        }
    }

    public class GetStateWithCountryKeySpec : Specification<State>
    {
        public GetStateWithCountryKeySpec(Guid countryId)
        {
            Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            Query.Where(s => s.CountryId == countryId).AsNoTracking();
        }
    }
}