using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class PrepaidPackageRedemptionGuardExtensions
    {
        public static void DuplicatePrepaidPackageRedemption(this IGuardClause guardClause,
            IEnumerable<PrepaidPackageRedemption> existingPrepaidPackageRedemptions,
            PrepaidPackageRedemption newPrepaidPackageRedemption, string parameterName)
        {
            if (existingPrepaidPackageRedemptions.Any(a =>
                    a.PrepaidPackageRedemptionId == newPrepaidPackageRedemption.PrepaidPackageRedemptionId))
            {
                throw new DuplicatePrepaidPackageRedemptionException("Cannot add duplicate prepaidPackageRedemption.",
                    parameterName);
            }
        }
    }
}