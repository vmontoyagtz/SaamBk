using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CityGuardExtensions
    {
        public static void DuplicateCity(this IGuardClause guardClause, IEnumerable<City> existingCities, City newCity,
            string parameterName)
        {
            if (existingCities.Any(a => a.CityId == newCity.CityId))
            {
                throw new DuplicateCityException("Cannot add duplicate city.", parameterName);
            }
        }
    }
}