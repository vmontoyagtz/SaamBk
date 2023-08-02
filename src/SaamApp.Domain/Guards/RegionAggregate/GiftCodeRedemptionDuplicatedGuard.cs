using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class GiftCodeRedemptionGuardExtensions
    {
        public static void DuplicateGiftCodeRedemption(this IGuardClause guardClause,
            IEnumerable<GiftCodeRedemption> existingGiftCodeRedemptions, GiftCodeRedemption newGiftCodeRedemption,
            string parameterName)
        {
            if (existingGiftCodeRedemptions.Any(a =>
                    a.GiftCodeRedemptionId == newGiftCodeRedemption.GiftCodeRedemptionId))
            {
                throw new DuplicateGiftCodeRedemptionException("Cannot add duplicate giftCodeRedemption.",
                    parameterName);
            }
        }
    }
}