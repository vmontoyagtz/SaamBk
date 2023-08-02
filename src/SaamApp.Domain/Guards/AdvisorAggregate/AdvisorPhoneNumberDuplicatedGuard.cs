using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorPhoneNumberGuardExtensions
    {
        public static void DuplicateAdvisorPhoneNumber(this IGuardClause guardClause,
            IEnumerable<AdvisorPhoneNumber> existingAdvisorPhoneNumbers, AdvisorPhoneNumber newAdvisorPhoneNumber,
            string parameterName)
        {
            if (existingAdvisorPhoneNumbers.Any(a => a.RowId == newAdvisorPhoneNumber.RowId))
            {
                throw new DuplicateAdvisorPhoneNumberException("Cannot add duplicate advisorPhoneNumber.",
                    parameterName);
            }
        }
    }
}