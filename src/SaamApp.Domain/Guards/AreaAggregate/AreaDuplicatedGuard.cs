using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AreaGuardExtensions
    {
        public static void DuplicateArea(this IGuardClause guardClause, IEnumerable<Area> existingAreas, Area newArea,
            string parameterName)
        {
            if (existingAreas.Any(a => a.AreaId == newArea.AreaId))
            {
                throw new DuplicateAreaException("Cannot add duplicate area.", parameterName);
            }
        }
    }
}