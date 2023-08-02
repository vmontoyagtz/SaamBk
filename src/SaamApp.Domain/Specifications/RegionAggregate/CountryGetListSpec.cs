using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CountryGetListByRegionIdSpec : Specification<Country>
    {
        public CountryGetListByRegionIdSpec(System.Guid regionId)
        {
            Query.OrderBy(country => country.CountryId)
                .AsNoTracking();
        }
    }
}