using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class RatingReasonGuardExtensions
    {
        public static void DuplicateRatingReason(this IGuardClause guardClause,
            IEnumerable<RatingReason> existingRatingReasons, RatingReason newRatingReason, string parameterName)
        {
            if (existingRatingReasons.Any(a => a.RatingReasonId == newRatingReason.RatingReasonId))
            {
                throw new DuplicateRatingReasonException("Cannot add duplicate ratingReason.", parameterName);
            }
        }
    }
}