using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class EmployeeGetListSpec : Specification<Employee>
    {
        public EmployeeGetListSpec()
        {
            Query.Where(employee => employee.IsActive == true)
                .AsNoTracking();
        }
    }
}