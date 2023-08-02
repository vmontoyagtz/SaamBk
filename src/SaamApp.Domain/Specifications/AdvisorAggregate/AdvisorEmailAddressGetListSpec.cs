using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorEmailAddressGetListSpec : Specification<AdvisorEmailAddress>
    {
        public AdvisorEmailAddressGetListSpec()
        {
            Query.OrderBy(advisorEmailAddress => advisorEmailAddress.RowId)
                .AsNoTracking();
        }
    }
}