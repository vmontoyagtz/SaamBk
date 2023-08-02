using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmployeeEmailAddressGetListSpec : Specification<EmployeeEmailAddress>
    {
        public EmployeeEmailAddressGetListSpec()
        {
            Query.OrderBy(employeeEmailAddress => employeeEmailAddress.RowId)
                .AsNoTracking();
        }
    }
}