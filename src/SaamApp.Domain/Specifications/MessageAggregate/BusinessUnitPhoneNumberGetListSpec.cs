using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitPhoneNumberGetListSpec : Specification<BusinessUnitPhoneNumber>
    {
        public BusinessUnitPhoneNumberGetListSpec()
        {
            Query.OrderBy(businessUnitPhoneNumber => businessUnitPhoneNumber.RowId)
                .AsNoTracking();
        }
    }
}