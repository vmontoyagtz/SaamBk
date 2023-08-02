using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitCategoryGetListSpec : Specification<BusinessUnitCategory>
    {
        public BusinessUnitCategoryGetListSpec()
        {
            Query.OrderBy(businessUnitCategory => businessUnitCategory.RowId)
                .AsNoTracking();
        }
    }
}