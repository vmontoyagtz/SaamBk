using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BusinessUnitTypeGuardExtensions
    {
        public static void DuplicateBusinessUnitType(this IGuardClause guardClause,
            IEnumerable<BusinessUnitType> existingBusinessUnitTypes, BusinessUnitType newBusinessUnitType,
            string parameterName)
        {
            if (existingBusinessUnitTypes.Any(a => a.BusinessUnitTypeId == newBusinessUnitType.BusinessUnitTypeId))
            {
                throw new DuplicateBusinessUnitTypeException("Cannot add duplicate businessUnitType.", parameterName);
            }
        }
    }
}