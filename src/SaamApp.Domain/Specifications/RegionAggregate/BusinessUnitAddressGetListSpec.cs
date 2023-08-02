using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitAddressGetListSpec : Specification<BusinessUnitAddress>
    {
        public BusinessUnitAddressGetListSpec()
        {
            Query.OrderBy(businessUnitAddress => businessUnitAddress.RowId)
                .AsNoTracking();
        }
    }
}