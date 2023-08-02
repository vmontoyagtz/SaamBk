using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BusinessUnitPhoneNumberGuardExtensions
    {
        public static void DuplicateBusinessUnitPhoneNumber(this IGuardClause guardClause,
            IEnumerable<BusinessUnitPhoneNumber> existingBusinessUnitPhoneNumbers,
            BusinessUnitPhoneNumber newBusinessUnitPhoneNumber, string parameterName)
        {
            if (existingBusinessUnitPhoneNumbers.Any(a => a.RowId == newBusinessUnitPhoneNumber.RowId))
            {
                throw new DuplicateBusinessUnitPhoneNumberException("Cannot add duplicate businessUnitPhoneNumber.",
                    parameterName);
            }
        }
    }
}