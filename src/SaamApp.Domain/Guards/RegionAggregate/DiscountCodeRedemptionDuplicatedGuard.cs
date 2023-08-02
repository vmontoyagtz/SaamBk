using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class DiscountCodeRedemptionGuardExtensions
    {
        public static void DuplicateDiscountCodeRedemption(this IGuardClause guardClause,
            IEnumerable<DiscountCodeRedemption> existingDiscountCodeRedemptions,
            DiscountCodeRedemption newDiscountCodeRedemption, string parameterName)
        {
            if (existingDiscountCodeRedemptions.Any(a => a.RowId == newDiscountCodeRedemption.RowId))
            {
                throw new DuplicateDiscountCodeRedemptionException("Cannot add duplicate discountCodeRedemption.",
                    parameterName);
            }
        }
    }
}