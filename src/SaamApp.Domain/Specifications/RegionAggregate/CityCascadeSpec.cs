using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAddressWithCityKeySpec : Specification<Address>
    {
        public GetAddressWithCityKeySpec(Guid cityId)
        {
            Guard.Against.NullOrEmpty(cityId, nameof(cityId));
            Query.Where(a => a.CityId == cityId).AsNoTracking();
        }
    }
}