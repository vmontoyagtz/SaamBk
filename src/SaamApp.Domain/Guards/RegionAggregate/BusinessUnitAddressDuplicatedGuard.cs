using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BusinessUnitAddressGuardExtensions
    {
        public static void DuplicateBusinessUnitAddress(this IGuardClause guardClause,
            IEnumerable<BusinessUnitAddress> existingBusinessUnitAddresses, BusinessUnitAddress newBusinessUnitAddress,
            string parameterName)
        {
            if (existingBusinessUnitAddresses.Any(a => a.RowId == newBusinessUnitAddress.RowId))
            {
                throw new DuplicateBusinessUnitAddressException("Cannot add duplicate businessUnitAddress.",
                    parameterName);
            }
        }
    }
}