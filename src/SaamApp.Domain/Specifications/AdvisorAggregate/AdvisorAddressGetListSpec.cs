using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorAddressGetListSpec : Specification<AdvisorAddress>
    {
        public AdvisorAddressGetListSpec()
        {
            Query.OrderBy(advisorAddress => advisorAddress.RowId)
                .AsNoTracking();
        }
    }
}