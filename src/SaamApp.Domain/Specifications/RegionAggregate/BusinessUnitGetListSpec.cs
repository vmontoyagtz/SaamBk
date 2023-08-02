using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitGetListSpec : Specification<BusinessUnit>
    {
        public BusinessUnitGetListSpec()
        {
            Query.Where(businessUnit => businessUnit.IsDeleted == false)
                .AsNoTracking();
        }
    }
}