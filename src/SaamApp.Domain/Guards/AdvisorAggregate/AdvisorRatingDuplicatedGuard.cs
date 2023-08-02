using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorRatingGuardExtensions
    {
        public static void DuplicateAdvisorRating(this IGuardClause guardClause,
            IEnumerable<AdvisorRating> existingAdvisorRatings, AdvisorRating newAdvisorRating, string parameterName)
        {
            if (existingAdvisorRatings.Any(a => a.RowId == newAdvisorRating.RowId))
            {
                throw new DuplicateAdvisorRatingException("Cannot add duplicate advisorRating.", parameterName);
            }
        }
    }
}