using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitTypeGetListSpec : Specification<BusinessUnitType>
    {
        public BusinessUnitTypeGetListSpec()
        {
            Query.OrderBy(businessUnitType => businessUnitType.BusinessUnitTypeId)
                .AsNoTracking();
        }
    }
}