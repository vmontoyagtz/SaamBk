using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GenderGetListSpec : Specification<Gender>
    {
        public GenderGetListSpec()
        {
            Query.OrderBy(gender => gender.GenderId)
                .AsNoTracking();
        }
    }
}