using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BusinessUnitEmailAddressGuardExtensions
    {
        public static void DuplicateBusinessUnitEmailAddress(this IGuardClause guardClause,
            IEnumerable<BusinessUnitEmailAddress> existingBusinessUnitEmailAddresses,
            BusinessUnitEmailAddress newBusinessUnitEmailAddress, string parameterName)
        {
            if (existingBusinessUnitEmailAddresses.Any(a => a.RowId == newBusinessUnitEmailAddress.RowId))
            {
                throw new DuplicateBusinessUnitEmailAddressException("Cannot add duplicate businessUnitEmailAddress.",
                    parameterName);
            }
        }
    }
}