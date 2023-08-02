using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class GenderGuardExtensions
    {
        public static void DuplicateGender(this IGuardClause guardClause, IEnumerable<Gender> existingGenders,
            Gender newGender, string parameterName)
        {
            if (existingGenders.Any(a => a.GenderId == newGender.GenderId))
            {
                throw new DuplicateGenderException("Cannot add duplicate gender.", parameterName);
            }
        }
    }
}