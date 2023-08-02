using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BusinessUnitGuardExtensions
    {
        public static void DuplicateBusinessUnit(this IGuardClause guardClause,
            IEnumerable<BusinessUnit> existingBusinessUnits, BusinessUnit newBusinessUnit, string parameterName)
        {
            if (existingBusinessUnits.Any(a => a.BusinessUnitId == newBusinessUnit.BusinessUnitId))
            {
                throw new DuplicateBusinessUnitException("Cannot add duplicate businessUnit.", parameterName);
            }
        }
    }
}