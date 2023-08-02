using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorAddressGuardExtensions
    {
        public static void DuplicateAdvisorAddress(this IGuardClause guardClause,
            IEnumerable<AdvisorAddress> existingAdvisorAddresses, AdvisorAddress newAdvisorAddress,
            string parameterName)
        {
            if (existingAdvisorAddresses.Any(a => a.RowId == newAdvisorAddress.RowId))
            {
                throw new DuplicateAdvisorAddressException("Cannot add duplicate advisorAddress.", parameterName);
            }
        }
    }
}