using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CountryByIdWithIncludesSpec : Specification<Country>, ISingleResultSpecification
    {
        public CountryByIdWithIncludesSpec(Guid countryId)
        {
            Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            Query.Where(country => country.CountryId == countryId)
                .Include(a => a.Region)
                .Include(b => b.Addresses)
                .Include(c => c.IdentityDocuments)
                .Include(c => c.States)
                .ThenInclude(c => c.Addresses)
                .AsNoTracking();
        }
    }
}