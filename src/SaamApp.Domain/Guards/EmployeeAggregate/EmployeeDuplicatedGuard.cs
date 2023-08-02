using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class EmployeeGuardExtensions
    {
        public static void DuplicateEmployee(this IGuardClause guardClause, IEnumerable<Employee> existingEmployees,
            Employee newEmployee, string parameterName)
        {
            if (existingEmployees.Any(a => a.EmployeeId == newEmployee.EmployeeId))
            {
                throw new DuplicateEmployeeException("Cannot add duplicate employee.", parameterName);
            }
        }
    }
}