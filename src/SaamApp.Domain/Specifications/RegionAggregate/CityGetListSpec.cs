using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CityGetListSpec : Specification<City>
    {
        public CityGetListSpec()
        {
            Query.OrderBy(city => city.CityId)
                .AsNoTracking();
        }
    }
}