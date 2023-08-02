using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorGuardExtensions
    {
        public static void DuplicateAdvisor(this IGuardClause guardClause, IEnumerable<Advisor> existingAdvisors,
            Advisor newAdvisor, string parameterName)
        {
            if (existingAdvisors.Any(a => a.AdvisorId == newAdvisor.AdvisorId))
            {
                throw new DuplicateAdvisorException("Cannot add duplicate advisor.", parameterName);
            }
        }
    }
}