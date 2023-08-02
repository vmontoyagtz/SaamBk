using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmployeePhoneNumberGetListSpec : Specification<EmployeePhoneNumber>
    {
        public EmployeePhoneNumberGetListSpec()
        {
            Query.OrderBy(employeePhoneNumber => employeePhoneNumber.RowId)
                .AsNoTracking();
        }
    }
}