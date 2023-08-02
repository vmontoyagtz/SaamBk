using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class DiscountCodeGuardExtensions
    {
        public static void DuplicateDiscountCode(this IGuardClause guardClause,
            IEnumerable<DiscountCode> existingDiscountCodes, DiscountCode newDiscountCode, string parameterName)
        {
            if (existingDiscountCodes.Any(a => a.DiscountCodeId == newDiscountCode.DiscountCodeId))
            {
                throw new DuplicateDiscountCodeException("Cannot add duplicate discountCode.", parameterName);
            }
        }
    }
}