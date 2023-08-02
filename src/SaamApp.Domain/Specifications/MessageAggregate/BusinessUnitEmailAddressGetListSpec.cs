using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitEmailAddressGetListSpec : Specification<BusinessUnitEmailAddress>
    {
        public BusinessUnitEmailAddressGetListSpec()
        {
            Query.OrderBy(businessUnitEmailAddress => businessUnitEmailAddress.RowId)
                .AsNoTracking();
        }
    }
}