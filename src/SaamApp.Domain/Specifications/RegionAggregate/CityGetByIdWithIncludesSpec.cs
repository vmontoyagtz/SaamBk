using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CityByIdWithIncludesSpec : Specification<City>, ISingleResultSpecification
    {
        public CityByIdWithIncludesSpec(Guid cityId)
        {
            Guard.Against.NullOrEmpty(cityId, nameof(cityId));
            Query.Where(city => city.CityId == cityId)
                .Include(a => a.State)
                .Include(b => b.Addresses)
                .AsNoTracking();
        }
    }
}