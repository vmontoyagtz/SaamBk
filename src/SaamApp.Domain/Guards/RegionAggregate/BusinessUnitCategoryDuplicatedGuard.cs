using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class BusinessUnitCategoryGuardExtensions
    {
        public static void DuplicateBusinessUnitCategory(this IGuardClause guardClause,
            IEnumerable<BusinessUnitCategory> existingBusinessUnitCategories,
            BusinessUnitCategory newBusinessUnitCategory, string parameterName)
        {
            if (existingBusinessUnitCategories.Any(a => a.RowId == newBusinessUnitCategory.RowId))
            {
                throw new DuplicateBusinessUnitCategoryException("Cannot add duplicate businessUnitCategory.",
                    parameterName);
            }
        }
    }
}