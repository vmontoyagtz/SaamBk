using Ardalis.Specification;
using SaamApp.Domain.Entities;
namespace SaamApp.Domain.Specifications
{
    public class CountryGetListSpec : Specification<Country>
    {
        public CountryGetListSpec()
        {
            Query.OrderBy(country => country.CountryId)
                .AsNoTracking();
        }
    }
}