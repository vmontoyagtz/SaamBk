using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class EmployeeAddressGuardExtensions
    {
        public static void DuplicateEmployeeAddress(this IGuardClause guardClause,
            IEnumerable<EmployeeAddress> existingEmployeeAddresses, EmployeeAddress newEmployeeAddress,
            string parameterName)
        {
            if (existingEmployeeAddresses.Any(a => a.RowId == newEmployeeAddress.RowId))
            {
                throw new DuplicateEmployeeAddressException("Cannot add duplicate employeeAddress.", parameterName);
            }
        }
    }
}