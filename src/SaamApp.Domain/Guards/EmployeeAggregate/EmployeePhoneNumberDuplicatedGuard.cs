using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class EmployeePhoneNumberGuardExtensions
    {
        public static void DuplicateEmployeePhoneNumber(this IGuardClause guardClause,
            IEnumerable<EmployeePhoneNumber> existingEmployeePhoneNumbers, EmployeePhoneNumber newEmployeePhoneNumber,
            string parameterName)
        {
            if (existingEmployeePhoneNumbers.Any(a => a.RowId == newEmployeePhoneNumber.RowId))
            {
                throw new DuplicateEmployeePhoneNumberException("Cannot add duplicate employeePhoneNumber.",
                    parameterName);
            }
        }
    }
}