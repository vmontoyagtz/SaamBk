using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmployeeAddressGetListSpec : Specification<EmployeeAddress>
    {
        public EmployeeAddressGetListSpec()
        {
            Query.OrderBy(employeeAddress => employeeAddress.RowId)
                .AsNoTracking();
        }
    }
}