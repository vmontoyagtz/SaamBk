using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class EmployeeEmailAddressGuardExtensions
    {
        public static void DuplicateEmployeeEmailAddress(this IGuardClause guardClause,
            IEnumerable<EmployeeEmailAddress> existingEmployeeEmailAddresses,
            EmployeeEmailAddress newEmployeeEmailAddress, string parameterName)
        {
            if (existingEmployeeEmailAddresses.Any(a => a.RowId == newEmployeeEmailAddress.RowId))
            {
                throw new DuplicateEmployeeEmailAddressException("Cannot add duplicate employeeEmailAddress.",
                    parameterName);
            }
        }
    }
}