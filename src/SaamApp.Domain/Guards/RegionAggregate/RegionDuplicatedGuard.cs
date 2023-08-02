using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class RegionGuardExtensions
    {
        public static void DuplicateRegion(this IGuardClause guardClause, IEnumerable<Region> existingRegions,
            Region newRegion, string parameterName)
        {
            if (existingRegions.Any(a => a.RegionId == newRegion.RegionId))
            {
                throw new DuplicateRegionException("Cannot add duplicate region.", parameterName);
            }
        }
    }
}