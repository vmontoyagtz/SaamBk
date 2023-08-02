using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CountryGuardExtensions
    {
        public static void DuplicateCountry(this IGuardClause guardClause, IEnumerable<Country> existingCountries,
            Country newCountry, string parameterName)
        {
            if (existingCountries.Any(a => a.CountryId == newCountry.CountryId))
            {
                throw new DuplicateCountryException("Cannot add duplicate country.", parameterName);
            }
        }
    }
}