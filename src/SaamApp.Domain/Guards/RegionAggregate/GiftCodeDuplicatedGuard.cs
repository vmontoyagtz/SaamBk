using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class GiftCodeGuardExtensions
    {
        public static void DuplicateGiftCode(this IGuardClause guardClause, IEnumerable<GiftCode> existingGiftCodes,
            GiftCode newGiftCode, string parameterName)
        {
            if (existingGiftCodes.Any(a => a.GiftCodeId == newGiftCode.GiftCodeId))
            {
                throw new DuplicateGiftCodeException("Cannot add duplicate giftCode.", parameterName);
            }
        }
    }
}