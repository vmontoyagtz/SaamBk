using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorEmailAddressGuardExtensions
    {
        public static void DuplicateAdvisorEmailAddress(this IGuardClause guardClause,
            IEnumerable<AdvisorEmailAddress> existingAdvisorEmailAddresses, AdvisorEmailAddress newAdvisorEmailAddress,
            string parameterName)
        {
            if (existingAdvisorEmailAddresses.Any(a => a.RowId == newAdvisorEmailAddress.RowId))
            {
                throw new DuplicateAdvisorEmailAddressException("Cannot add duplicate advisorEmailAddress.",
                    parameterName);
            }
        }
    }
}