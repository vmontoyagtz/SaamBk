using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class RegionAreaAdvisorCategoryGuardExtensions
    {
        public static void DuplicateRegionAreaAdvisorCategory(this IGuardClause guardClause,
            IEnumerable<RegionAreaAdvisorCategory> existingRegionAreaAdvisorCategories,
            RegionAreaAdvisorCategory newRegionAreaAdvisorCategory, string parameterName)
        {
            if (existingRegionAreaAdvisorCategories.Any(a =>
                    a.RegionAreaAdvisorCategoryId == newRegionAreaAdvisorCategory.RegionAreaAdvisorCategoryId))
            {
                throw new DuplicateRegionAreaAdvisorCategoryException("Cannot add duplicate regionAreaAdvisorCategory.",
                    parameterName);
            }
        }
    }
}